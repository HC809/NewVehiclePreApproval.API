using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewVehiclePreApproval.Application.CalculateFinancing;
using NewVehiclePreApproval.Application.Requests.GetRequests;
using NewVehiclePreApproval.Application.Requests.RegisterRequest;

namespace NewVehiclePreApproval.API.Controllers.Requests;
[Route("api/requests")]
[ApiController]
public class RequestsController : ControllerBase
{
    private readonly ISender _sender;

    public RequestsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetRequests(CancellationToken cancellationToken)
    {
        var query = new GetRequestsQuery();
        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }


    [HttpPost("create")]
    public async Task<IActionResult> RegisterRequest(RegisterNewVehicleApprovalRequest request, CancellationToken cancellationToken)
    {
        var command = new RegisterRequestCommand(
            request.Dealership,
            request.VendorName,
            request.ClientFullName,
            request.ClientEmail,
            request.ClientPhoneNumber,
            request.ClientDni,
            request.ClientRtn,
            request.ClientEstimatedMonthlyIncome,
            request.ClientState,
            request.ClientCity,
            request.ClientHomeAddress,
            request.ClientWorkOrBusinessName,
            request.ClientWorkOrBusinessDescription,
            request.ClientWorkOrBusinessAddress,
            request.VehicleBrand,
            request.VehicleModel,
            request.VehicleYear,
            request.VehicleType,
            request.VehiclePrice);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure) return BadRequest(result.Error);

        return Ok(result.Value);
    }

    [HttpPost("calculate")]
    public async Task<IActionResult> CalculateFinancingRequest(CalculateFinancingRequest request, CancellationToken cancellationToken)
    {
        var command = new CalculateFinancingCommand(
            request.RequestId,
            request.LoanTermMonths,
            request.DownPaymentPercentage);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure) return BadRequest(result.Error);

        return Ok(result.Value);
    }
}
