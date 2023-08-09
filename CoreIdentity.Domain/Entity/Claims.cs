using CoreIdentity.Domain.Common;

namespace CoreIdentity.Domain.Entity
{
    public class Claims : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}