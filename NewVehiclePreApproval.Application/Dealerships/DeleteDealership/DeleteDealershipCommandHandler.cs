using NewVehiclePreApproval.Application.Abstractions.Messaging;
using NewVehiclePreApproval.Domain.Abstractions;
using NewVehiclePreApproval.Domain.Dealerships;

namespace NewVehiclePreApproval.Application.Dealerships.DeleteDealership;
internal class DeleteDealershipCommandHandler : ICommandHandler<DeleteDealershipCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDealershipRepository _dealershipRepository;

    public DeleteDealershipCommandHandler(IUnitOfWork unitOfWork, IDealershipRepository dealershipRepository)
    {
        _unitOfWork = unitOfWork;
        _dealershipRepository = dealershipRepository;
    }

    public async Task<Result<bool>> Handle(DeleteDealershipCommand request, CancellationToken cancellationToken)
    {
        var dealership = await _dealershipRepository.GetByIdAsync(request.Id, cancellationToken);
        if (dealership == null)
            return Result.Failure<bool>(DealershipErrors.DealershipNotFound);

        _dealershipRepository.Delete(dealership);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}

