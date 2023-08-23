using MediatR;

namespace CoreIdentity.Application.Requests.Roles.Queries.GetRolesId;

public record GetRolesByIdQuery(int RoleId) : IRequest<RolesDto>
{
}
