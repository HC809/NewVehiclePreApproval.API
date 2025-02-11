using NewVehiclePreApproval.Application.Abstractions.Messaging;
using NewVehiclePreApproval.Domain.Abstractions;
using NewVehiclePreApproval.Domain.Dealerships;

namespace NewVehiclePreApproval.Application.Dealerships.UpdateDealership;
internal class UpdateDealershipCommandHandler : ICommandHandler<UpdateDealershipCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDealershipRepository _dealershipRepository;

    public UpdateDealershipCommandHandler(IUnitOfWork unitOfWork, IDealershipRepository dealershipRepository)
    {
        _unitOfWork = unitOfWork;
        _dealershipRepository = dealershipRepository;
    }

    public async Task<Result<bool>> Handle(UpdateDealershipCommand request, CancellationToken cancellationToken)
    {
        var dealership = await _dealershipRepository.GetByIdAsync(request.Id, cancellationToken);

        if (dealership == null)
            return Result.Failure<bool>(DealershipErrors.DealershipNotFound);

        // Validar si ya existe otra concesionaria con el mismo nombre
        if (await _dealershipRepository.ExistsByNameExcludingIdAsync(request.Id, request.Name, cancellationToken))
            return Result.Failure<bool>(DealershipErrors.DuplicateDealershipName);

        // Validar si ya existe otra concesionaria con el mismo número de teléfono
        if (!string.IsNullOrEmpty(request.PhoneNumber) &&
            await _dealershipRepository.ExistsByPhoneNumberExcludingIdAsync(request.Id, request.PhoneNumber, cancellationToken))
            return Result.Failure<bool>(DealershipErrors.DuplicateDealershipPhoneNumber);

        // Validar si ya existe otra concesionaria con el mismo email
        if (!string.IsNullOrEmpty(request.Email) &&
            await _dealershipRepository.ExistsByEmailExcludingIdAsync(request.Id, request.Email, cancellationToken))
            return Result.Failure<bool>(DealershipErrors.DuplicateDealershipEmail);

        dealership.UpdateDetails(request.Name, request.Address, request.PhoneNumber, request.Email);
        _dealershipRepository.Update(dealership);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}

