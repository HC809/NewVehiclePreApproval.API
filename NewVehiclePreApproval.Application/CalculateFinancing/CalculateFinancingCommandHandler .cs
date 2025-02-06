using NewVehiclePreApproval.Application.Abstractions.Messaging;
using NewVehiclePreApproval.Application.Requests;
using NewVehiclePreApproval.Domain.Abstractions;
using NewVehiclePreApproval.Domain.Requests;

namespace NewVehiclePreApproval.Application.CalculateFinancing;
internal class CalculateFinancingCommandHandler : ICommandHandler<CalculateFinancingCommand, FinancingResponse>
{
    private readonly IRequestRepository _requestRepository;

    public CalculateFinancingCommandHandler(IRequestRepository requestRepository)
    {
        _requestRepository = requestRepository;
    }

    public async Task<Result<FinancingResponse>> Handle(CalculateFinancingCommand command, CancellationToken cancellationToken)
    {
        decimal annualInterestRate = 20.5m;
        //decimal closingCosts = 6000;
        decimal gpsCost = 460;

        var request = await _requestRepository.GetByIdAsync(command.RequestId);
        if (request == null)
        {
            return Result.Failure<FinancingResponse>(RequestErrors.RequestNotFound);
        }

        // Información del cliente y vehículo
        var client = request.ClientInformation;
        var vehicle = request.VehicleInformation;

        // 1. Valor de la garantía
        var collateralValue = vehicle.Price * 25.2m;

        // 2. Valor de la prima
        var downPaymentValue = collateralValue * (command.DownPaymentPercentage / 100);

        // 3. Crédito solicitado
        var requestedLoanAmount = collateralValue - downPaymentValue;

        // 4. Capacidad máxima de pago
        var maximumPaymentCapacity = client.EstimatedMonthlyIncome * 0.3m;

        // 5. Relación Crédito/Garantía
        var loanToValueRatio = requestedLoanAmount / collateralValue;

        // 6. Cuota mensual (Capital + Intereses)
        var monthlyPayment = annualInterestRate > 0
            ? CalculatePMT(annualInterestRate, command.LoanTermMonths, requestedLoanAmount)
            : 0;

        // 7. Seguro de vida y accidentes personales
        var lifeAndAccidentInsurance = (requestedLoanAmount / 1000) * (6 / 12m);

        // 8. Seguro de vehículo automotriz
        var vehicleInsurance = ((collateralValue * 0.0215m) * 1.15m) / 12;

        // 9. Total cuota
        var totalMonthlyPayment = monthlyPayment + lifeAndAccidentInsurance + vehicleInsurance + gpsCost;

        // 10. Relación Cuota/Ingreso (redondeado)
        var paymentToIncomeRounded = Math.Round(totalMonthlyPayment / 0.3m, 0);

        // 11. Relación Cuota/Ingreso (en porcentaje)
        var paymentToIncomePercentage = totalMonthlyPayment / client.EstimatedMonthlyIncome;

        // 12. Impuesto Seguro Vehículo
        var vehicleInsuranceTax = (collateralValue * 0.0215m) * 0.15m;

        // Construir resultado
        var result = new FinancingResponse(
            Math.Round(collateralValue, 2),
            Math.Round(downPaymentValue, 2),
            Math.Round(requestedLoanAmount, 2),
            Math.Round(maximumPaymentCapacity, 2),
            Math.Round(loanToValueRatio, 2),
            Math.Round(monthlyPayment, 2),
            Math.Round(lifeAndAccidentInsurance, 2),
            Math.Round(vehicleInsurance, 2),
            Math.Round(totalMonthlyPayment, 2),
            Math.Round(paymentToIncomeRounded, 2),
            Math.Round(paymentToIncomePercentage, 4),
            Math.Round(vehicleInsuranceTax, 2));

        return Result.Success(result);
    }

    // Función para calcular la Cuota Mensual
    private decimal CalculatePMT(decimal annualInterestRate, int loanTermMonths, decimal loanAmount)
    {
        if (annualInterestRate == 0)
            return 0;

        var monthlyRate = annualInterestRate / 100 / 12;
        return (loanAmount * monthlyRate) / (1 - (decimal)Math.Pow((double)(1 + monthlyRate), -loanTermMonths));
    }
}
