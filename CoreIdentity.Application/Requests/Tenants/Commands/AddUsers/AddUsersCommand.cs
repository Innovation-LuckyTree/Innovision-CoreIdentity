using MediatR;

namespace CoreIdentity.Application.Requests.Tenants.Commands.AddUsers;

public record AddUsersCommand(Guid TenantId, IEnumerable<Guid> UserIds) : IRequest<Unit>;
