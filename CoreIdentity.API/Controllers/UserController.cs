using CoreIdentity.Application.Requests.Users.Commands;
using CoreIdentity.Application.Requests.Users.Commands.AddUserRole;
using CoreIdentity.Application.Requests.Users.Commands.ResetUserPassword;
using CoreIdentity.Application.Requests.Users.Queries.Getusers;
using CoreIdentity.Application.Requests.Users.Queries.UpdateUserInfo;
using CoreIdentity.Application.Requests.Users.Queries.UpdateUserPassword;
using CoreIdentity.Application.Requests.Users.Queries.UpdateUserPasswordById;
using Microsoft.AspNetCore.Mvc;

namespace CoreIdentity.API.Controllers;

/// <summary>
/// Users controller
/// </summary>
public class UsersController : ApiBaseController
{
    /// <summary>
    /// Get users
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetUsersQuery(), cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Create User
    /// </summary>
    /// <param name="request"></param>  
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Put([FromBody]CreateUserCommand request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    /// <summary>
    /// Update User Information
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]UpdateUserInfoCommand request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    /// <summary>
    /// Add Role to User
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("role")]
    public async Task<IActionResult> AddUserRole([FromBody]AddUserRoleCommand request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    /// <summary>
    /// Reset User Password
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("password/reset")]
    public async Task<IActionResult> ResetUserPassword([FromBody]ResetUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    /// <summary>
    /// Update User Password
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("password")]
    public async Task<IActionResult> UpdatePassword([FromBody]UpdateUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    /// <summary>
    /// Update User Password but should be pass thru OTP process
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("password/update")]
    public async Task<IActionResult> UpdateUserPassword([FromBody]UpdateUserPasswordByIdCommand request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        return Ok(response);
    }
}    
