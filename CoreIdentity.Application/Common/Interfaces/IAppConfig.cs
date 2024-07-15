using CoreIdentity.Application.Common.Models;

namespace CoreIdentity.Application.Common.Interfaces;

public interface IAppConfig
{
    int TokenExpiryHours { get; set; }
    int LockTimeMinutes { get; set; }
    JwtConfig JwtConfig { get; set; }
}
