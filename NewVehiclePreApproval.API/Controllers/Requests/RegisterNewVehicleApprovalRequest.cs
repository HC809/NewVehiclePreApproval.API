namespace NewVehiclePreApproval.API.Controllers.Requests;

public sealed record RegisterNewVehicleApprovalRequest(
    string Dealership,
    string VendorName,
    string ClientFullName,
    string? ClientEmail,
    string ClientPhoneNumber,
    string ClientDni,
    string? ClientRtn,
    decimal ClientEstimatedMonthlyIncome,
    string ClientState,
    string ClientCity,
    string ClientHomeAddress,
    string ClientWorkOrBusinessName,
    string ClientWorkOrBusinessDescription,
    string ClientWorkOrBusinessAddress,
    string VehicleBrand,
    string VehicleModel,
    int VehicleYear,
    string VehicleType,
    decimal VehiclePrice);
