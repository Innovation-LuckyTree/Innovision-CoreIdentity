namespace CoreIdentity.Domain.Common
{
    public class AuditableEntity
    {
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? LastModifiedBy { get; set; }
    }
}