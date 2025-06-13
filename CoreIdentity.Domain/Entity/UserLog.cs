namespace CoreIdentity.Domain.Entity;

public class UserLog
{
    public long UserLogId { get; set; }
    public Guid LogId { get; set; }
    public Guid UserId { get; set; }
    public Guid? TenantId { get; set; }
    public string IpAddress { get; set; }
    public DateTimeOffset LoginDate { get; set; } = DateTime.UtcNow;
    public string RefreshToken { get; set; }
    public DateTimeOffset ExpiryTime { get; set; }

    public virtual User User { get; set; }
    public virtual Tenant Tenant { get; set; }
    public virtual UserAccessToken UserAccessTokens { get; set; }
}

