namespace NewVehiclePreApproval.API.Controllers.Requests;

public sealed record CalculateFinancingRequest(
    Guid RequestId,
    int LoanTermMonths,
    decimal DownPaymentPercentage);
