using CoreIdentity.Domain.Common;

namespace CoreIdentity.Domain.Entity;

public class UserAccessToken : AuditableEntity
{
    public UserAccessToken()
    {
        UserAccessTokenLogs = new HashSet<UserAccessTokenLog>();
    }
    
    public long UserAccessTokenId { get; set; }
    public Guid UserId { get; set; }
    public long UserLogId { get; set; }
    public string AccessToken { get; set; }
    public string AccessTokenKey { get; set; }
    public bool Used { get; set; } = false;

    public virtual User User { get; set; }
    public virtual UserLog UserLog { get; set; }
    public virtual ICollection<UserAccessTokenLog> UserAccessTokenLogs { get; set; }
}
