namespace CoreIdentity.Application.Requests.Tenants.Queries.GetTenants;

public record TenantVm(IEnumerable<TenantDto> Tenants)
{
    public int Total {
        get {
            return Tenants.Count();
        }
    }
}