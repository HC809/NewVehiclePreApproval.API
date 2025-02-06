
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;

namespace NewVehiclePreApproval.Infrastructure.Exceptions;
public class SqlServerExceptionMapper : ISqlServerExceptionMapper
{
    private static readonly Dictionary<int, (int StatusCode, string Title, string Detail)> SqlServerErrorMap = new()
    {
        { 2627, (StatusCodes.Status409Conflict, "Unique Constraint Violation", "A record with the provided identifier already exists.") }, // Unique constraint violation
        { 547, (StatusCodes.Status400BadRequest, "Foreign Key Violation", "The operation violates a foreign key constraint.") }, // Foreign key violation
        { 2601, (StatusCodes.Status409Conflict, "Unique Constraint Violation", "A record with the provided identifier already exists.") }, // Duplicate key
    };

    public SqlServerExceptionDetails Map(SqlException sqlException)
    {
        if (SqlServerErrorMap.TryGetValue(sqlException.Number, out var errorInfo))
        {
            return new SqlServerExceptionDetails(
                errorInfo.StatusCode,
                "SqlServerError",
                errorInfo.Title,
                errorInfo.Detail,
                new[] { sqlException.Message });
        }
        else
        {
            return new SqlServerExceptionDetails(
                StatusCodes.Status500InternalServerError,
                "SqlServerError",
                "Unexpected Error",
                $"An unexpected database error has occurred: {sqlException.Message}",
                new[] { sqlException.Message });
        }
    }
}
