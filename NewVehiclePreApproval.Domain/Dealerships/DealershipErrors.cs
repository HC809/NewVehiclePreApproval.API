using NewVehiclePreApproval.Domain.Abstractions;

namespace NewVehiclePreApproval.Domain.Dealerships;

public static class DealershipErrors
{
    public static readonly Error DealershipNotFound = new(
        "DealershipNotFound",
        "No se encontró la concesionaria.");

    public static readonly Error DuplicateDealershipName = new(
        "DuplicateDealershipName",
        "Ya existe una concesionaria registrada con este nombre.");

    public static readonly Error DuplicateDealershipPhoneNumber = new(
        "DuplicateDealershipPhoneNumber",
        "Ya existe una concesionaria registrada con este número de teléfono.");

    public static readonly Error DuplicateDealershipEmail = new(
        "DuplicateDealershipEmail",
        "Ya existe una concesionaria registrada con este correo electrónico.");

    public static readonly Error AdminUserNotAssigned = new(
        "AdminUserNotAssigned",
        "No se ha asignado un usuario administrador a la concesionaria.");

    public static readonly Error CantDeleteDefaultDealership = new(
        "CantDeleteDefaultDealership",
        "No se puede eliminar la concesionaria COFISA porque es la concesionaria predeterminada.");
}
