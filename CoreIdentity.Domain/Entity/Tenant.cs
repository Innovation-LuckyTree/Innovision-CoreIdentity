using CoreIdentity.Domain.Common;

namespace CoreIdentity.Domain.Entity
{
    public class Tenant : AuditableEntity
    {
        public Tenant()
        {
            TenantAudiences = new HashSet<TenantAudience>();
            TenantUsers = new HashSet<TenantUser>();
            TenantKeys = new HashSet<TenantKey>();
            UserLogs = new HashSet<UserLog>();
        }

        public Guid Id { get; set; }
        public string TenantName { get; set; }
        public int Type { get; set; }
        public Guid? AdminUserId { get; set; }
        public string DefaultPassword { get; set; }
        public string AppKey { get; set; }
        public string Issuer { get; set; }
        public string Domain { get; set; }

        public virtual ICollection<TenantUser> TenantUsers { get; set; }
        public virtual ICollection<TenantKey> TenantKeys { get; set; }
        public virtual ICollection<TenantAudience> TenantAudiences { get; set; }
        public virtual ICollection<UserLog> UserLogs { get; set; }
        public virtual User AdminUser { get; set; }
    }
}
