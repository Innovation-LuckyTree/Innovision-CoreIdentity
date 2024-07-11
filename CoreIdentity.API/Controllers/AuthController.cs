using CoreIdentity.Application.Requests.Tenants.Queries.GetAuthToken;
using CoreIdentity.Application.Requests.UserDevices.Queries.GetAuthDeviceToken;
using CoreIdentity.Application.Requests.Users.Queries.GetUserToken;
using CoreIdentity.Application.Requests.Users.Queries.GetRefreshToken;
using Microsoft.AspNetCore.Mvc;

namespace CoreIdentity.API.Controllers;

public class AuthController : ApiBaseController
{

    ///TODO: Add Auth set up that will allow the user to login using token

    /// <summary>
    /// Get User Token using user credentials
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("account/login")]
    public async Task<IActionResult> Login([FromBody] GetUserTokenQuery request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        if (response == null)
            return NotFound();

        return Ok(response);
    }

    /// <summary>
    /// Get User Token using user credentials
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("tenant")]
    public async Task<IActionResult> GetTenantToken([FromBody] GetAuthTokenQuery request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    /// <summary>
    /// Login using device token
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("device")]
    public async Task<IActionResult> GetUserDeviceToken([FromBody] GetAuthDeviceTokenQuery request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    [HttpPost("token/refresh")]
    public async Task<IActionResult> RefreshUserToken([FromBody] GetRefreshTokenQuery request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        if (response == null)
            return NotFound();

        return Ok(response);
    }
}