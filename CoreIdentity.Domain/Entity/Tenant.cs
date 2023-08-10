using CoreIdentity.Domain.Common;

namespace CoreIdentity.Domain.Entity
{
    public class Tenant : AuditableEntity
    {
        public Guid Id { get; set; }
        public string TenantName { get; set; }
        public string Domain { get; set; }
        public Guid AdminUserId { get; set; }

        public virtual ICollection<TenantUser> TenantUsers { get; set; }
        public virtual ICollection<TenantKey> TenantKeys { get; set; }
        public virtual User AdminUser { get; set; }
    }
}