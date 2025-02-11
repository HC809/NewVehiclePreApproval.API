using NewVehiclePreApproval.Domain.Abstractions;

namespace NewVehiclePreApproval.Domain.Dealerships;

public sealed class Dealership : Entity
{
    public Dealership(
        Guid id,
        string name,
        string? address,
        string? phoneNumber,
        string? email
        //Guid adminUserId
        ) : base(id)
    {
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        Email = email;
        //AdminUserId = adminUserId;
    }

    public string Name { get; private set; }
    public string? Address { get; private set; }
    public string? PhoneNumber { get; private set; }
    public string? Email { get; private set; }
    //public Guid AdminUserId { get; private set; } // Usuario administrador asignado por COFISA

    public static Dealership Create(
        string name,
        string? address,
        string? phoneNumber,
        string? email)
    {
        return new Dealership(Guid.CreateVersion7(), name, address, phoneNumber, email);
    }

    public void UpdateDetails(string name, string? address, string? phoneNumber, string? email)
    {
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    //public void AssignAdmin(Guid adminUserId)
    //{
    //    AdminUserId = adminUserId;
    //}

    // Empty constructor for EF Core
#nullable disable
    internal Dealership() { }
#nullable restore
}
