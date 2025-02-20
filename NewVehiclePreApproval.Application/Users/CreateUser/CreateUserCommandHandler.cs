using NewVehiclePreApproval.Application.Abstractions.AppSettings;
using NewVehiclePreApproval.Application.Abstractions.Messaging;
using NewVehiclePreApproval.Application.Services;
using NewVehiclePreApproval.Domain.Abstractions;
using NewVehiclePreApproval.Domain.Dealerships;
using NewVehiclePreApproval.Domain.Users;

namespace NewVehiclePreApproval.Application.Users.CreateUser;
internal class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IDealershipRepository _dealershipRepository;
    private readonly Guid _cofisaDealershipId;
    private readonly IPasswordService _passwordService;

    public CreateUserCommandHandler(
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        IDealershipRepository dealershipRepository,
        IBusinessSettings businessSettings,
        IPasswordService passwordService)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _dealershipRepository = dealershipRepository;
        _cofisaDealershipId = businessSettings.CofisaDealershipId;
        _passwordService = passwordService;
    }

    public async Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // Validaciones
        if (await _userRepository.ExistsByEmailAsync(request.Email, cancellationToken))
        {
            return Result.Failure<Guid>(UserErrors.DuplicateUserEmail);
        }

        // Validar que la concesionaria exista
        Dealership? dealership = await _dealershipRepository.GetByIdAsync(request.DealershipId, cancellationToken);
        if (dealership is null)
        {
            return Result.Failure<Guid>(UserErrors.InvalidDealership);
        }

        // Convertir Role de string a enum y validar
        if (!Enum.TryParse<UserRole>(request.Role, true, out var userRole))
        {
            return Result.Failure<Guid>(UserErrors.InvalidUserRole);
        }

        VerificationType userVerificationType = VerificationType.Backoffice; // Valor por defecto
        Guid dealershipId = request.DealershipId;
        string temporalHashPassword = string.Empty;

        switch (userRole)
        {
            case UserRole.Dealership_Admin:
                // Verificar que la concesionaria no sea COFISA
                if (dealershipId == _cofisaDealershipId)
                {
                    return Result.Failure<Guid>(UserErrors.InvalidDealershipAssignment);
                }

                // Generar una contraseña temporal para usuarios Backoffice
                temporalHashPassword = GenerateTemporaryPassword();
                break;

            case UserRole.IT_Admin:
            case UserRole.BusinessDevelopment_Admin:
            case UserRole.BusinessDevelopment_User:
                userVerificationType = VerificationType.ActiveDirectory; // Asignar verificación por Active Directory
                dealershipId = _cofisaDealershipId; // Asignar concesionaria COFISA
                break;

            default:
                return Result.Failure<Guid>(UserErrors.InvalidUserRole);
        }

        // Crear nuevo usuario
        var newUser = User.Create(
            request.Name,
            request.Email,
            dealershipId,
            temporalHashPassword,
            userRole,
            userVerificationType,
            true // Se asume que el usuario está activo al crearse
        );

        _userRepository.Add(newUser);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return newUser.Id;
    }

    private string GenerateTemporaryPassword()
    {
        var tempHashPassword = _passwordService.GetHashPassword(Guid.NewGuid().ToString().Substring(0, 8));
        return tempHashPassword;
    }
}
