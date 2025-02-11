using FluentValidation;

namespace NewVehiclePreApproval.Application.Dealerships.CreateDealership;

internal class CreateDealershipCommandValidator : AbstractValidator<CreateDealershipCommand>
{
    private const string RequiredErrorMessage = "El campo '{PropertyName}' es obligatorio";

    public CreateDealershipCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(RequiredErrorMessage)
            .MaximumLength(255).WithMessage("El '{PropertyName}' no debe superar los 255 caracteres")
            .WithName("Nombre de la Concesionaria");

        RuleFor(x => x.Address)
            .MaximumLength(500).WithMessage("La '{PropertyName}' no debe superar los 500 caracteres")
            .WithName("Dirección de la Concesionaria");

        RuleFor(x => x.PhoneNumber)
            .Matches(@"^\d{8,20}$").WithMessage("El '{PropertyName}' debe contener entre 8 y 20 dígitos")
            .When(x => !string.IsNullOrEmpty(x.PhoneNumber)) // Solo validar si hay un número ingresado
            .WithName("Número de Teléfono");

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("El '{PropertyName}' debe ser un correo electrónico válido")
            .When(x => !string.IsNullOrEmpty(x.Email)) // Solo validar si hay un correo ingresado
            .WithName("Correo Electrónico"); ;

        //RuleFor(x => x.AdminUserId)
        //    .NotEmpty().WithMessage(RequiredErrorMessage)
        //    .WithName("Usuario Administrador");
    }
}
