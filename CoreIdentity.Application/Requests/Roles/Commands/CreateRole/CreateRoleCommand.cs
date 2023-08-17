using MediatR;

namespace CoreIdentity.Application.Requests.Roles.Commands.CreateRole;

public record CreateRoleCommand(string RoleName) : IRequest<Unit>;
