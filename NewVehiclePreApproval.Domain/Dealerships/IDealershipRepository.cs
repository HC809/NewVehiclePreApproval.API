using NewVehiclePreApproval.Domain.Requests;

namespace NewVehiclePreApproval.Domain.Dealerships;
public interface IDealershipRepository
{
    Task<Dealership?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Dealership dealership);
    void Update(Dealership dealership);
    void Delete(Dealership dealership);

    Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken = default);
    Task<bool> ExistsByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken = default);
    Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<bool> ExistsByNameExcludingIdAsync(Guid id, string name, CancellationToken cancellationToken = default);
    Task<bool> ExistsByPhoneNumberExcludingIdAsync(Guid id, string phoneNumber, CancellationToken cancellationToken = default);
    Task<bool> ExistsByEmailExcludingIdAsync(Guid id, string email, CancellationToken cancellationToken = default);
}

