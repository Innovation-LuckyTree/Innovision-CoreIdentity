using MediatR;

namespace CoreIdentity.Application.Requests.Users.Commands.AddUserRole;

public record AddUserRoleCommand(Guid UserId, int RoleId) : IRequest<Unit>;
