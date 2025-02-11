using NewVehiclePreApproval.Application.Abstractions.Messaging;

namespace NewVehiclePreApproval.Application.Dealerships.DeleteDealership;
public record DeleteDealershipCommand(Guid Id) : ICommand<bool>;

