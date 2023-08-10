using CoreIdentity.Domain.Common;

namespace CoreIdentity.Domain.Entity
{
    public class TenantKey : AuditableEntity
    {
        public int TenantKeyId { get; set; }
        public Guid TenantId { get; set; }
        public string Key { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}