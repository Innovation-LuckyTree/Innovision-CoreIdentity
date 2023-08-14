using CoreIdentity.Domain.Common;

namespace CoreIdentity.Domain.Entity
{
    public class User : AuditableEntity
    {
        public Guid Id { get; set; }
        public int IdNumber { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public bool ChangePassword { get; set; }
        public bool EmailConfirm { get; set; }

        public virtual ICollection<TenantUser> TenantUsers { get; set; }
        public virtual ICollection<UserKey> UserKeys { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
        public virtual ICollection<UserClaims> UserClaims { get; set; }
        public virtual ICollection<UserLog> UserLogs { get; set; }
        public virtual Tenant TenantAdmin { get; set; }
    }
}