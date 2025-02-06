﻿namespace NewVehiclePreApproval.Infrastructure.Exceptions;
public sealed record PostgresExceptionDetails(
    int Status,
    string Type,
    string Title,
    string Detail,
    IEnumerable<object>? Errors);
