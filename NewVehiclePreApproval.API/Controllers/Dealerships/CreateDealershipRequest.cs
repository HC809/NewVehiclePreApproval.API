namespace NewVehiclePreApproval.API.Controllers.Dealerships;

public sealed record CreateDealershipRequest(
    string Name,
    string? Address,
    string? PhoneNumber,
    string? Email);

