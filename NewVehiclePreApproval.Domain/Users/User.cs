using NewVehiclePreApproval.Domain.Abstractions;

namespace NewVehiclePreApproval.Domain.Users;
public sealed class User : Entity
{
    private User(
        Guid id,
        string name,
        string email,
        Guid dealershipId,
        string? hashPassword,
        UserRole role,
        VerificationType verificationType,
        bool isActive) : base(id)
    {
        Name = name;
        Email = email;
        DealershipId = dealershipId;
        HashPassword = hashPassword;
        Role = role;
        VerificationType = verificationType;
        IsActive = isActive;
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public Guid DealershipId { get; private set; }
    public string? HashPassword { get; private set; }
    public UserRole Role { get; private set; }
    public VerificationType VerificationType { get; private set; }
    public bool IsActive { get; private set; }

    public static User Create(
        string name,
        string email,
        Guid dealershipId,
        string? hashPassword,
        UserRole role,
        VerificationType verificationType,
        bool isActive)
    {
        var user = new User(Guid.CreateVersion7(), name, email, dealershipId, hashPassword, role, verificationType, isActive);

        return user;
    }

    public void UpdateDetails(string name, string email, Guid dealershipId, string? hashPassword, UserRole role, bool isActive)
    {
        Name = name;
        Email = email;
        DealershipId = dealershipId;
        HashPassword = hashPassword;
        Role = role;
        IsActive = isActive;
    }

#nullable disable
    internal User() { }
#nullable restore
}
