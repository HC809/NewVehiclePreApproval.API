using FluentValidation;

namespace NewVehiclePreApproval.Application.Requests.RegisterRequest;
internal class RegisterRequestCommandValidator : AbstractValidator<RegisterRequestCommand>
{
    private const string RequiredErrorMessage = "El campo '{PropertyName}' es obligatorio";
    private const string OnlyDigitsErrorMessage = "El '{PropertyName}' solo debe contener dígitos";

    public RegisterRequestCommandValidator()
    {
        // Validación del vendedor
        RuleFor(x => x.Dealership)
            .NotEmpty().WithMessage(RequiredErrorMessage)
            .MaximumLength(250).WithMessage("La '{PropertyName}' no debe superar los 250 caracteres")
            .WithName("Concesionaria");

        RuleFor(x => x.VendorName)
            .NotEmpty().WithMessage(RequiredErrorMessage)
            .MaximumLength(200).WithMessage("El '{PropertyName}' no debe superar los 200 caracteres")
            .WithName("Nombre del Vendedor");

        // Validación del cliente
        RuleFor(x => x.ClientFullName)
            .NotEmpty().WithMessage(RequiredErrorMessage)
            .MaximumLength(250).WithMessage("El '{PropertyName}' no debe superar los 250 caracteres")
            .WithName("Nombre Completo del Cliente");

        When(x => !string.IsNullOrEmpty(x.ClientEmail), () =>
            RuleFor(x => x.ClientEmail)
                .NotEmpty().WithMessage(RequiredErrorMessage)
                .EmailAddress().WithMessage("El '{PropertyName}' no es válido")
                .WithName("Correo Electrónico del Cliente"));

        RuleFor(x => x.ClientPhoneNumber)
            .NotEmpty().WithMessage(RequiredErrorMessage)
            .Matches(@"^\d{8}$").WithMessage("El '{PropertyName}' debe tener 8 dígitos")
            .WithName("Número de Teléfono del Cliente");

        RuleFor(x => x.ClientDni)
            .NotEmpty().WithMessage(RequiredErrorMessage)
            .Length(13).WithMessage("El '{PropertyName}' debe tener 13 dígitos")
            .Matches("^[0-9]+$").WithMessage(OnlyDigitsErrorMessage)
            .WithName("DNI del Cliente");

        When(x => !string.IsNullOrEmpty(x.ClientRtn), () =>
            RuleFor(x => x.ClientRtn)
                .NotEmpty().WithMessage(RequiredErrorMessage)
                .Length(14).WithMessage("El '{PropertyName}' debe tener 14 dígitos")
                .Matches("^[0-9]+$").WithMessage(OnlyDigitsErrorMessage)
                .WithName("RTN del Cliente"));

        RuleFor(x => x.ClientEstimatedMonthlyIncome)
            .GreaterThan(0).WithMessage("El '{PropertyName}' debe ser mayor a 0")
            .WithName("Ingreso Mensual Estimado");

        RuleFor(x => x.ClientHomeAddress)
                .NotEmpty().WithMessage(RequiredErrorMessage)
                .MaximumLength(500).WithMessage("La '{PropertyName}' no debe superar los 500 caracteres")
                .WithName("Dirección de Domicilio");

        RuleFor(x => x.ClientWorkOrBusinessName)
                .NotEmpty().WithMessage(RequiredErrorMessage)
                .MaximumLength(250).WithMessage("El '{PropertyName}' no debe superar los 250 caracteres")
                .WithName("Nombre del Trabajo o Comercio");

        RuleFor(x => x.ClientWorkOrBusinessDescription)
                .MaximumLength(2000).WithMessage("La '{PropertyName}' no debe superar los 2,000 caracteres")
                .WithName("Descripción del Trabajo o Comercio");

        RuleFor(x => x.ClientWorkOrBusinessAddress)
                .NotEmpty().WithMessage(RequiredErrorMessage)
                .MaximumLength(500).WithMessage("La '{PropertyName}' no debe superar los 500 caracteres")
                .WithName("Dirección del Trabajo o Comercio");

        // Validación del vehículo
        RuleFor(x => x.VehicleBrand)
                .NotEmpty().WithMessage(RequiredErrorMessage)
                .MaximumLength(50).WithMessage("La '{PropertyName}' no debe superar los 50 caracteres")
                .WithName("Marca del Vehículo");

        RuleFor(x => x.VehicleModel)
                .NotEmpty().WithMessage(RequiredErrorMessage)
                .MaximumLength(50).WithMessage("El '{PropertyName}' no debe superar los 50 caracteres")
                .WithName("Modelo del Vehículo");

        RuleFor(x => x.VehicleYear)
                .InclusiveBetween(1886, DateTime.Now.Year).WithMessage("El '{PropertyName}' debe ser un año válido")
                .WithName("Año del Vehículo");

        RuleFor(x => x.VehicleType)
                .NotEmpty().WithMessage(RequiredErrorMessage)
                .MaximumLength(50).WithMessage("La '{PropertyName}' no debe superar los 50 caracteres")
                .WithName("Tipo de Vehículo");

        RuleFor(x => x.VehiclePrice)
                .GreaterThan(0).WithMessage("El '{PropertyName}' debe ser mayor a 0")
                .WithName("Precio del Vehículo");

        // Validación adicional para estados y ciudades
        RuleFor(x => x.ClientState).NotEmpty().WithMessage(RequiredErrorMessage).WithName("Estado");
        RuleFor(x => x.ClientCity).NotEmpty().WithMessage(RequiredErrorMessage).WithName("Ciudad");
    }
}

