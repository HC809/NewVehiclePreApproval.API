using NewVehiclePreApproval.Application.Abstractions.Messaging;
using NewVehiclePreApproval.Application.Requests;

namespace NewVehiclePreApproval.Application.CalculateFinancing;
public record CalculateFinancingCommand(
    Guid RequestId,
    int LoanTermMonths,
    decimal DownPaymentPercentage) : ICommand<FinancingResponse>;
