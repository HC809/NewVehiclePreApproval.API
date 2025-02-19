using Microsoft.EntityFrameworkCore;
using NewVehiclePreApproval.Domain.Users;

namespace NewVehiclePreApproval.Infrastructure.Repositories;
internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        => await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

    public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default)
        => await _dbContext.Set<User>().AnyAsync(u => u.Email == email, cancellationToken);


    public async Task<bool> ExistsByEmailExcludingIdAsync(Guid id, string email, CancellationToken cancellationToken = default)
        => await _dbContext.Set<User>().AnyAsync(u => u.Email == email && u.Id != id, cancellationToken);

}
