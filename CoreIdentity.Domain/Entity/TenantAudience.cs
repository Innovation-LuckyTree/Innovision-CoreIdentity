using CoreIdentity.Domain.Common;

namespace CoreIdentity.Domain.Entity
{
    public class TenantAudience : AuditableEntity
    {
        public Guid TenantId { get; set; }
        public Guid AudienceId { get; set; }
        
        public Tenant TenanId { get; set; }
        public Tenant Audience { get; set; }
    }
}