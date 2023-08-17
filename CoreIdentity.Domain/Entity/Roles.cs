using CoreIdentity.Domain.Common;

namespace CoreIdentity.Domain.Entity
{
    public class Roles : AuditableEntity
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}