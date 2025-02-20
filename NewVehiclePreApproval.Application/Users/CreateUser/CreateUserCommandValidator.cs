using FluentValidation;
using NewVehiclePreApproval.Domain.Users;

namespace NewVehiclePreApproval.Application.Users.CreateUser;
internal class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    private const string RequiredErrorMessage = "El campo '{PropertyName}' es obligatorio";

    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(RequiredErrorMessage)
            .MaximumLength(255).WithMessage("El '{PropertyName}' no debe superar los 255 caracteres")
            .WithName("Nombre del Usuario");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(RequiredErrorMessage)
            .EmailAddress().WithMessage("El '{PropertyName}' debe ser un correo electrónico válido")
            .WithName("Correo Electrónico");

        RuleFor(x => x.DealershipId)
            .NotEmpty().WithMessage(RequiredErrorMessage)
            .Must(BeAValidGuid).WithMessage("El '{PropertyName}' no es un GUID válido")
            .WithName("Concesionaria");

        RuleFor(x => x.Role)
            .Must(role => Enum.IsDefined(typeof(UserRole), role))
            .WithMessage("El rol especificado no es válido.")
            .WithName("Rol del Usuario");
    }

    private bool BeAValidGuid(Guid dealershipId) => dealershipId != Guid.Empty;
}
