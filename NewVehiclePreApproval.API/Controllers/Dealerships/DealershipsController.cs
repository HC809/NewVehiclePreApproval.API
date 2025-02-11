using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewVehiclePreApproval.Application.Dealerships.CreateDealership;
using NewVehiclePreApproval.Application.Dealerships.DeleteDealership;
using NewVehiclePreApproval.Application.Dealerships.UpdateDealership;

namespace NewVehiclePreApproval.API.Controllers.Dealerships;

[Route("api/dealerships")]
[ApiController]
public class DealershipsController : ControllerBase
{
    private readonly ISender _sender;

    public DealershipsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateDealership(CreateDealershipRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateDealershipCommand(
            request.Name,
            request.Address,
            request.PhoneNumber,
            request.Email);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure) return BadRequest(result.Error);

        return Ok(result.Value);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateDealership(Guid id, UpdateDealershipRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateDealershipCommand(
            id,
            request.Name,
            request.Address,
            request.PhoneNumber,
            request.Email);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure) return NotFound(result.Error);

        return Ok(result.Value);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteDealership(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteDealershipCommand(id);
        var result = await _sender.Send(command, cancellationToken);
        if (result.IsFailure) return NotFound(result.Error);

        return Ok(result.Value);
    }
}
