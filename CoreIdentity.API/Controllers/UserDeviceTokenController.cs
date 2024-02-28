using CoreIdentity.Application.Requests.UserDevices.Commands.GetUserDeviceToken;
using Microsoft.AspNetCore.Mvc;

namespace CoreIdentity.API.Controllers;

public class UserDeviceTokenController : ApiBaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateUserDeviceToken([FromBody]CreateUserDeviceTokenCommand request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        if (response == null)
            return NotFound();
            
        return Ok(response);
    }
}