namespace NewVehiclePreApproval.API.Controllers.Dealerships;

public sealed record UpdateDealershipRequest(
    Guid Id,
    string Name,
    string? Address,
    string? PhoneNumber,
    string? Email);
