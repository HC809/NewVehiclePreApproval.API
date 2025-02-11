using NewVehiclePreApproval.Application.Abstractions.Messaging;

namespace NewVehiclePreApproval.Application.Dealerships.UpdateDealership;
public record UpdateDealershipCommand(
    Guid Id,
    string Name,
    string? Address,
    string? PhoneNumber,
    string? Email) : ICommand<bool>;

