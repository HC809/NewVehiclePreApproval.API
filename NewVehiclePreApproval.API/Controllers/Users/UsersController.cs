using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewVehiclePreApproval.Application.Users.CreateUser;

namespace NewVehiclePreApproval.API.Controllers.Users;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ISender _sender;

    public UsersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateUserCommand(
            request.Name,
            request.Email,
            request.DealershipId,
            request.Role);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure) return BadRequest(result.Error);

        return Ok(result.Value);
    }
}

