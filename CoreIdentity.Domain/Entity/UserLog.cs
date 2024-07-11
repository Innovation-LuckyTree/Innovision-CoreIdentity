namespace CoreIdentity.Domain.Entity
{
    public class UserLog
    {
        public int UserLogId { get; set; }
        public Guid UserId { get; set; }
        public Guid? TenantId { get; set; }
        public string IpAddress { get; set; }
        public DateTimeOffset LoginDate { get; set; } = DateTime.Now;
        public string RefreshToken { get; set; }
        public DateTime ExpiryTime { get; set; }

        public User User { get; set; }
        public Tenant Tenant { get; set; }
    }
}