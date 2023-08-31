using MediatR;

namespace CoreIdentity.Application.Requests.Tenants.Queries.GetAuthToken;

public record GetAuthTokenQuery(Guid ClientId, Guid ResourceId, string Key) : IRequest<TenantTokenDto>;
