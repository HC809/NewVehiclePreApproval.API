using NewVehiclePreApproval.Domain.Abstractions;

namespace NewVehiclePreApproval.Domain.Requests;
public static class RequestErrors
{
    public static readonly Error RequestNotFound = new(
    "RequestNotFound",
    "No se encontro la solicitud.");
}
