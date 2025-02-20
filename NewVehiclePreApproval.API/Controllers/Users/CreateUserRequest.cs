namespace NewVehiclePreApproval.API.Controllers.Users;

public sealed record CreateUserRequest(
    string Name,
    string Email,
    Guid DealershipId,
    string Role);
