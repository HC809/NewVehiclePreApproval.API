namespace NewVehiclePreApproval.Domain.Users;
public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    void Add(User user);
    void Update(User user);
    void Delete(User user);

    Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<bool> ExistsByEmailExcludingIdAsync(Guid id, string email, CancellationToken cancellationToken = default);
}
