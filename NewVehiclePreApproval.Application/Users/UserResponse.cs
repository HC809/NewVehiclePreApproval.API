namespace NewVehiclePreApproval.Application.Users;

public sealed class UserResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Dealership { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string Role { get; init; } = string.Empty;
    public string VerificationType { get; init; } = string.Empty;
    public bool IsActive { get; private set; }
}
