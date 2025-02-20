using BC = BCrypt.Net.BCrypt;

namespace NewVehiclePreApproval.Application.Services;
internal interface IPasswordService
{
    string GetHashPassword(string password);
    bool VerifyPassword(string password, string hashedPassword);
}

internal sealed class PasswordService : IPasswordService
{
    public string GetHashPassword(string password) => BC.HashPassword(password);

    public bool VerifyPassword(string password, string hashedPassword) => BC.Verify(password, hashedPassword);
}
