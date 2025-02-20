using NewVehiclePreApproval.Application.Abstractions.AppSettings;
using NewVehiclePreApproval.Application.Abstractions.Messaging;
using NewVehiclePreApproval.Domain.Abstractions;
using NewVehiclePreApproval.Domain.Dealerships;

namespace NewVehiclePreApproval.Application.Dealerships.DeleteDealership;
internal class DeleteDealershipCommandHandler : ICommandHandler<DeleteDealershipCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDealershipRepository _dealershipRepository;
    private readonly Guid _cofisaDealershipId;

    public DeleteDealershipCommandHandler(IUnitOfWork unitOfWork, IDealershipRepository dealershipRepository, IBusinessSettings businessSettings)
    {
        _unitOfWork = unitOfWork;
        _dealershipRepository = dealershipRepository;
        _cofisaDealershipId = businessSettings.CofisaDealershipId;
    }

    public async Task<Result<bool>> Handle(DeleteDealershipCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == _cofisaDealershipId)
            return Result.Failure<bool>(DealershipErrors.CantDeleteDefaultDealership);

        var dealership = await _dealershipRepository.GetByIdAsync(request.Id, cancellationToken);
        if (dealership == null)
            return Result.Failure<bool>(DealershipErrors.DealershipNotFound);

        _dealershipRepository.Delete(dealership);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}

