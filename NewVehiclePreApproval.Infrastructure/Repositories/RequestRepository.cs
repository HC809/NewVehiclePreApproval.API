using NewVehiclePreApproval.Domain.Requests;

namespace NewVehiclePreApproval.Infrastructure.Repositories;
internal sealed class RequestRepository : Repository<Request>, IRequestRepository
{
    public RequestRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
