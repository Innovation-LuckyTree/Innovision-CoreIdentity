using MediatR;

namespace CoreIdentity.Application.Requests.Tenants.Commands.AddAudience;

public record AddAudienceCommand(Guid TenantId, IEnumerable<Guid> Audiences) : IRequest<Unit>;
