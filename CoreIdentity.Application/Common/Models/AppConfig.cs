using CoreIdentity.Application.Common.Interfaces;

namespace CoreIdentity.Application.Common.Models;

public class AppConfig : IAppConfig
{
    public int TokenExpiryHours { get; set; }
    public int LockTimeMinutes { get; set; }
    public JwtConfig JwtConfig { get; set; }
}
