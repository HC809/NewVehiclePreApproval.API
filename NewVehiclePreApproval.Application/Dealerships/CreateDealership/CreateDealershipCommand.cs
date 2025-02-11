using NewVehiclePreApproval.Application.Abstractions.Messaging;

namespace NewVehiclePreApproval.Application.Dealerships.CreateDealership;

public record CreateDealershipCommand(
    string Name,
    string? Address,
    string? PhoneNumber,
    string? Email) : ICommand<Guid>;

