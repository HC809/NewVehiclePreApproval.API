using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NewVehiclePreApproval.Application.Exceptions;
using NewVehiclePreApproval.Infrastructure.Exceptions;

namespace NewVehiclePreApproval.API.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly ISqlServerExceptionMapper _postgresExceptionMapper;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, ISqlServerExceptionMapper postgresExceptionMapper)
    {
        _next = next;
        _logger = logger;
        _postgresExceptionMapper = postgresExceptionMapper;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var exceptionDetails = GetExceptionDetails(exception);

        _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

        await WriteProblemDetailsAsync(context, exceptionDetails);
    }

    private ExceptionDetails GetExceptionDetails(Exception exception)
    {
        return exception switch
        {
            ValidationException validationException => new ExceptionDetails(
                StatusCodes.Status422UnprocessableEntity,
                "ValidationFailure",
                "Validation Error",
                validationException.Message,
                validationException.Errors),

            DbUpdateException dbUpdateException when dbUpdateException.InnerException is SqlException sqlExeption
                => MapSqlServerExceptionToExceptionDetails(sqlExeption),

            _ => new ExceptionDetails(
                StatusCodes.Status500InternalServerError,
                "ServerError",
                "Server Error",
                exception.Message,
                null)
        }; ;
    }

    private ExceptionDetails MapSqlServerExceptionToExceptionDetails(SqlException sqlExeption)
    {
        var postgresExceptionDetails = _postgresExceptionMapper.Map(sqlExeption);

        return new ExceptionDetails(
            postgresExceptionDetails.Status,
            postgresExceptionDetails.Type,
            postgresExceptionDetails.Title,
            postgresExceptionDetails.Detail,
            postgresExceptionDetails.Errors);
    }

    private static async Task WriteProblemDetailsAsync(HttpContext context, ExceptionDetails exceptionDetails)
    {
        var problemDetails = new ProblemDetails
        {
            Status = exceptionDetails.Status,
            Type = exceptionDetails.Type,
            Title = exceptionDetails.Title,
            Detail = exceptionDetails.Detail,
        };

        if (exceptionDetails.Errors is not null)
        {
            problemDetails.Extensions["errors"] = exceptionDetails.Errors;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = exceptionDetails.Status;
        await context.Response.WriteAsJsonAsync(problemDetails);
    }

    internal sealed record ExceptionDetails(
       int Status,
       string Type,
       string Title,
       string Detail,
       IEnumerable<object>? Errors);
}
