using MediatR;

namespace CoreIdentity.Application.Requests.Tenants.Queries.GetTenantById;

public record GetTenantByIdQuery(Guid TenantId) : IRequest<TenantDto>;
