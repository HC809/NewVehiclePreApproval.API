namespace NewVehiclePreApproval.Domain.Requests;
public record VehicleInformation(
    string Brand,
    string Model,
    int Year,
    string Type,
    decimal Price);
