using CoreIdentity.Application.Requests.Roles.Commands.CreateRole;
using CoreIdentity.Application.Requests.Roles.Queries.GetRoles;
using CoreIdentity.Application.Requests.Roles.Queries.GetRolesId;
using Microsoft.AspNetCore.Mvc;

namespace CoreIdentity.API.Controllers;

/// <summary>
/// Roles Controller
/// </summary>
public class RolesController : ApiBaseController
{
    private readonly ILogger<RolesController> _logger;

    /// <summary>
    /// Get all roles list
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetRolesQuery(), cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Get Role information by id
    /// </summary>
    /// <param name="roleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{roleId}")]
    public async Task<IActionResult> GetById(int roleId, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetRolesByIdQuery(roleId), cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Add new Role
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        return Ok(result);
    }
}