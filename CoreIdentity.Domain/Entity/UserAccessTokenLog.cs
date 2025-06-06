namespace CoreIdentity.Domain.Entity;

public class UserAccessTokenLog
{
    public long UserAccessTokenLogId { get; set; }
    public long UserAccessTokenId { get; set; }
    public string GameName { get; set; }
    public DateTime LogDate { get; set; } = DateTime.Now;

    public virtual UserAccessToken UserAccessToken { get; set; }
}