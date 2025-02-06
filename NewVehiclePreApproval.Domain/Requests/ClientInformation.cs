namespace NewVehiclePreApproval.Domain.Requests;
public record ClientInformation(
    string FullName,
    string? Email,
    string PhoneNumber,
    string Dni,
    string? Rtn,
    decimal EstimatedMonthlyIncome,
    string State,
    string City,
    string HomeAddress,
    string WorkOrBusinessName,
    string WorkOrBusinessDescription,
    string WorkOrBusinessAddress);
