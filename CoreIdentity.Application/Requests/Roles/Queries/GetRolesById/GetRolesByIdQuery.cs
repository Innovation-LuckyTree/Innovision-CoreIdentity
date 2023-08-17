using MediatR;

namespace CoreIdentity.Application.Requests.Roles.Queries.GetRolesId;

public record GetRolesByIdQuery(Guid RoleId) : IRequest<RolesDto>
{
}
