namespace CoreIdentity.Domain.Common
{
    public class AuditableEntity
    {
        public DateTimeOffset CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTimeOffset? LastModifiedBy { get; set; }
    }
}