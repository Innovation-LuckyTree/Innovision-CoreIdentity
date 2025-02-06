using MediatR;

namespace CoreIdentity.Application.Requests.Roles.Commands.CreateRole;

public record CreateRoleCommand(int Id, string RoleName) : IRequest<Unit>;
