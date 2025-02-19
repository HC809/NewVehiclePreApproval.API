namespace NewVehiclePreApproval.Domain.Users;
public enum VerificationType
{
    Backoffice,       // Usuario creado desde el backoffice para concesionarias.
    ActiveDirectory   // Usuario empleado en COFISA que inicia sesión mediante Active Directory.
}
