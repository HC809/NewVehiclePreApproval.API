namespace NewVehiclePreApproval.Application.Dealerships;
public sealed class DealershipResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string? Address { get; init; }
    public string? PhoneNumber { get; init; }
    public string? Email { get; init; }
}
