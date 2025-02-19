using NewVehiclePreApproval.Domain.Abstractions;

namespace NewVehiclePreApproval.Domain.Users;
public static class UserErrors
{
    public static readonly Error UserNotFound = new(
         "UserNotFound",
         "No se encontró el usuario.");

    public static readonly Error DuplicateUserEmail = new(
        "DuplicateUserEmail",
        "Ya existe un usuario registrado con este correo electrónico.");

    public static readonly Error UserNotActive = new(
        "UserNotActive",
        "El usuario no está activo en el sistema.");

    public static readonly Error UnauthorizedUser = new(
        "UnauthorizedUser",
        "El usuario no tiene permisos para realizar esta acción.");

    public static readonly Error RoleNotAssigned = new(
        "RoleNotAssigned",
        "No se ha asignado un rol al usuario.");

    public static readonly Error PasswordTooWeak = new(
        "PasswordTooWeak",
        "La contraseña proporcionada no cumple con los requisitos mínimos de seguridad.");

    public static readonly Error PasswordResetFailed = new(
        "PasswordResetFailed",
        "No se pudo restablecer la contraseña del usuario.");

    public static readonly Error ActiveDirectoryIntegrationFailed = new(
        "ActiveDirectoryIntegrationFailed",
        "No se pudo autenticar al usuario a través de Active Directory.");

    public static readonly Error InvalidUserCredentials = new(
        "InvalidUserCredentials",
        "Las credenciales proporcionadas son incorrectas.");
}
