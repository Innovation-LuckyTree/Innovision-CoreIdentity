using CoreIdentity.Application.Requests.Tenants.Commands.AddAudience;
using CoreIdentity.Application.Requests.Tenants.Commands.AddUsers;
using CoreIdentity.Application.Requests.Tenants.Commands.CreateTenant;
using CoreIdentity.Application.Requests.Tenants.Queries.GetTenantById;
using CoreIdentity.Application.Requests.Tenants.Queries.GetTenants;
using Microsoft.AspNetCore.Mvc;

namespace CoreIdentity.API.Controllers;

/// <summary>
/// Tenant Controller
/// </summary>
public class TenantController : ApiBaseController
{
    /// <summary>
    /// Get All Tenants
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetTenantsQuery(), cancellationToken);

        return Ok(result);
    }


    /// <summary>
    /// Get tenent information by tenant Id
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{tenantId}")]
    public async Task<IActionResult> GetById(Guid tenantId, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetTenantByIdQuery(tenantId), cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Create new tenant
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Put(CreateTenantCommand request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// add audience to tenant
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("audience")]
    public async Task<IActionResult> AddTenantAudience(AddAudienceCommand request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Add users to tenant
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("users")]
    public async Task<IActionResult> AddUser(AddUsersCommand request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return Ok(result);
    }
}