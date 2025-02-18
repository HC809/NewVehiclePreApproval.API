using NewVehiclePreApproval.Domain.Abstractions;

namespace NewVehiclePreApproval.Domain.Requests;
public sealed class Request : Entity
{
    public Request(
        Guid id,
        SellerInformation sellerInformation,
        ClientInformation clientInformation,
        VehicleInformation vehicleInformation) : base(id)
    {
        SellerInformation = sellerInformation;
        ClientInformation = clientInformation;
        VehicleInformation = vehicleInformation;
        Status = RequestStatus.Pending;
    }

    public string Test { get; private set; }

    public SellerInformation SellerInformation { get; private set; }
    public ClientInformation ClientInformation { get; private set; }
    public VehicleInformation VehicleInformation { get; private set; }
    public RequestStatus Status { get; private set; }
    public string? RejectionReason { get; private set; }

    public static Request Create(
        SellerInformation sellerInformation,
        ClientInformation clientInformation,
        VehicleInformation vehicleInformation)
    {
        return new Request(Guid.CreateVersion7(), sellerInformation, clientInformation, vehicleInformation);
    }

    public void Approve()
    {
        Status = RequestStatus.Approved;
    }

    public void Reject(string reason)
    {
        Status = RequestStatus.Rejected;
        RejectionReason = reason;
    }

    //Empty constructor for EF Core
#nullable disable
    internal Request() { }
#nullable restore
}
