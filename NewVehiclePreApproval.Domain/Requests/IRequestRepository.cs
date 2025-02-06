namespace NewVehiclePreApproval.Domain.Requests;
public interface IRequestRepository
{
    Task<Request?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Request tenant);
}
