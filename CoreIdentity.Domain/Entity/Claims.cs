using CoreIdentity.Domain.Common;

namespace CoreIdentity.Domain.Entity
{
    public class Claims : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<UserClaims> UserClaims { get; set; }
    }
}