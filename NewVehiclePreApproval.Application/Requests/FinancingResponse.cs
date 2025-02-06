namespace NewVehiclePreApproval.Application.Requests;
public record FinancingResponse(
        decimal CollateralValue, // Valor de la garantía
        decimal DownPaymentValue, // Valor de la prima
        decimal RequestedLoanAmount, // Crédito solicitado
        decimal MaximumPaymentCapacity, // Capacidad de pago máxima
        decimal LoanToValueRatio, // Relación Crédito/Garantía
        decimal MonthlyPayment, // Cuota Mensual (Capital + Intereses)
        decimal LifeAndAccidentInsurance, // Seguro de vida y accidentes personales
        decimal VehicleInsurance, // Seguro de vehículo automotriz
        decimal TotalMonthlyPayment, // Total cuota
        decimal PaymentToIncomeRounded, // Relación cuota/ingreso (redondeado)
        decimal PaymentToIncomePercentage, // Relación cuota/ingreso (%)
        decimal VehicleInsuranceTax // Impuesto Seguro Vehículo
    );
