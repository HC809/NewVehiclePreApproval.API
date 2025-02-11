using NewVehiclePreApproval.Application.Abstractions.Messaging;
using NewVehiclePreApproval.Domain.Abstractions;
using NewVehiclePreApproval.Domain.Dealerships;

namespace NewVehiclePreApproval.Application.Dealerships.CreateDealership;

internal class CreateDealershipCommandHandler : ICommandHandler<CreateDealershipCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDealershipRepository _dealershipRepository;

    public CreateDealershipCommandHandler(IUnitOfWork unitOfWork, IDealershipRepository dealershipRepository)
    {
        _unitOfWork = unitOfWork;
        _dealershipRepository = dealershipRepository;
    }

    public async Task<Result<Guid>> Handle(CreateDealershipCommand request, CancellationToken cancellationToken)
    {
        // Validaciones
        if (await _dealershipRepository.ExistsByNameAsync(request.Name))
            return Result.Failure<Guid>(DealershipErrors.DuplicateDealershipName);

        if (!string.IsNullOrEmpty(request.PhoneNumber) && await _dealershipRepository.ExistsByPhoneNumberAsync(request.PhoneNumber))
            return Result.Failure<Guid>(DealershipErrors.DuplicateDealershipPhoneNumber);

        if (!string.IsNullOrEmpty(request.Email) && await _dealershipRepository.ExistsByEmailAsync(request.Email))
            return Result.Failure<Guid>(DealershipErrors.DuplicateDealershipEmail);

        // Crear la nueva concesionaria
        var newDealership = Dealership.Create(
            request.Name,
            request.Address,
            request.PhoneNumber,
            request.Email);

        _dealershipRepository.Add(newDealership);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return newDealership.Id;
    }
}
