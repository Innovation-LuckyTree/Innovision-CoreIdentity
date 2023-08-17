using CoreIdentity.Domain.Entity;

namespace CoreIdentity.Application.Common.Extensions;

public static class TenantExtensions
{
    public static IEnumerable<string> GetTenantAudiences(this Tenant tenant)
    {
        if ((tenant?.TenantAudiences?.Count ?? 0) != 0)
        {
            return tenant.TenantAudiences.Select(o => o.Audience.TenantName);
        }

        return Enumerable.Empty<string>();
    }
}