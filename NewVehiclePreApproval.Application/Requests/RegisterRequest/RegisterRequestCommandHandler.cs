
using NewVehiclePreApproval.Application.Abstractions.Messaging;
using NewVehiclePreApproval.Domain.Abstractions;
using NewVehiclePreApproval.Domain.Requests;

namespace NewVehiclePreApproval.Application.Requests.RegisterRequest;
internal class RegisterRequestCommandHandler : ICommandHandler<RegisterRequestCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRequestRepository _requestRepository;

    public RegisterRequestCommandHandler(IUnitOfWork unitOfWork, IRequestRepository requestRepository)
    {
        _unitOfWork = unitOfWork;
        _requestRepository = requestRepository;
    }

    public async Task<Result<Guid>> Handle(RegisterRequestCommand request, CancellationToken cancellationToken)
    {
        var vendorInformation = new SellerInformation(request.Dealership, request.VendorName);

        var clientInformation = new ClientInformation(
            request.ClientFullName,
            request.ClientEmail,
            request.ClientPhoneNumber,
            request.ClientDni,
            request.ClientRtn,
            request.ClientEstimatedMonthlyIncome,
            request.ClientState,
            request.ClientCity,
            request.ClientHomeAddress,
            request.ClientWorkOrBusinessName,
            request.ClientWorkOrBusinessDescription,
            request.ClientWorkOrBusinessAddress);

        var vehicleInformation = new VehicleInformation(
            request.VehicleBrand,
            request.VehicleModel,
            request.VehicleYear,
            request.VehicleType,
            request.VehiclePrice);

        var newVehicleRequest = Request.Create(vendorInformation, clientInformation, vehicleInformation);

        _requestRepository.Add(newVehicleRequest);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return newVehicleRequest.Id;
    }
}
