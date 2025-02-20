using NewVehiclePreApproval.Application.Abstractions.Messaging;
using NewVehiclePreApproval.Domain.Users;

namespace NewVehiclePreApproval.Application.Users.CreateUser;
public record CreateUserCommand(
    string Name,
    string Email,
    Guid DealershipId,
    string Role
) : ICommand<Guid>;
