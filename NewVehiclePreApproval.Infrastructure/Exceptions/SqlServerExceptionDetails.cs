namespace NewVehiclePreApproval.Infrastructure.Exceptions;
public sealed record SqlServerExceptionDetails(
    int Status,
    string Type,
    string Title,
    string Detail,
    IEnumerable<object>? Errors);
