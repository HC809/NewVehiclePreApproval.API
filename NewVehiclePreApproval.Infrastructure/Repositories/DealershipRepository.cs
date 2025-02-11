using Microsoft.EntityFrameworkCore;
using NewVehiclePreApproval.Domain.Dealerships;

namespace NewVehiclePreApproval.Infrastructure.Repositories;

internal sealed class DealershipRepository : Repository<Dealership>, IDealershipRepository
{
    public DealershipRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken = default)
        => await _dbContext.Set<Dealership>().AnyAsync(x => x.Name == name, cancellationToken);

    public async Task<bool> ExistsByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken = default)
        => await _dbContext.Set<Dealership>().AnyAsync(x => x.PhoneNumber == phoneNumber, cancellationToken);

    public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default)
        => await _dbContext.Set<Dealership>().AnyAsync(x => x.Email == email, cancellationToken);

    public async Task<bool> ExistsByNameExcludingIdAsync(Guid id, string name, CancellationToken cancellationToken = default)
        => await _dbContext.Set<Dealership>()
            .AnyAsync(x => x.Name == name && x.Id != id, cancellationToken);

    public async Task<bool> ExistsByPhoneNumberExcludingIdAsync(Guid id, string phoneNumber, CancellationToken cancellationToken = default)
        => await _dbContext.Set<Dealership>()
            .AnyAsync(x => x.PhoneNumber == phoneNumber && x.Id != id, cancellationToken);

    public async Task<bool> ExistsByEmailExcludingIdAsync(Guid id, string email, CancellationToken cancellationToken = default)
        => await _dbContext.Set<Dealership>()
            .AnyAsync(x => x.Email == email && x.Id != id, cancellationToken);
}
