namespace NewVehiclePreApproval.Application.Requests;
public sealed class RequestResponse
{
    public Guid Id { get; init; }
    public string Status { get; init; } = string.Empty;
    public string RejectionReason { get; init; } = string.Empty;
    public string CreatedAt { get; init; } = string.Empty;

    public SellerResponse SellerInformation { get; init; } = new SellerResponse();
    public ClientResponse ClientInformation { get; init; } = new ClientResponse();
    public VehicleResponse VehicleInformation { get; init; } = new VehicleResponse();
}

public sealed class SellerResponse
{
    public string Dealership { get; init; } = string.Empty;
    public string VendorName { get; init; } = string.Empty;
}

public sealed class ClientResponse
{
    public string FullName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string PhoneNumber { get; init; } = string.Empty;
    public string Dni { get; init; } = string.Empty;
    public string Rtn { get; init; } = string.Empty;
    public decimal EstimatedMonthlyIncome { get; init; }
    public string State { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string HomeAddress { get; init; } = string.Empty;
    public string WorkOrBusinessName { get; init; } = string.Empty;
    public string WorkOrBusinessDescription { get; init; } = string.Empty;
    public string WorkOrBusinessAddress { get; init; } = string.Empty;
}

public sealed class VehicleResponse
{
    public string Brand { get; init; } = string.Empty;
    public string Model { get; init; } = string.Empty;
    public int Year { get; init; }
    public string Type { get; init; } = string.Empty;
    public decimal Price { get; init; }
}

