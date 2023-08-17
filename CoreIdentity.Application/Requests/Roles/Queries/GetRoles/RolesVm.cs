namespace CoreIdentity.Application.Requests.Roles.Queries.GetRoles;

public record RolesVm(IEnumerable<RolesDto> Roles)
{
    public int Count {
        get
        {
            return Roles.Count();
        }
    }
}