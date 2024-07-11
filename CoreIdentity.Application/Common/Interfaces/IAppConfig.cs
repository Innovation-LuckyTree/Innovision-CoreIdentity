using CoreIdentity.Application.Common.Models;

namespace CoreIdentity.Application.Common.Interfaces;

public interface IAppConfig
{
    public int TokenExpiryHours { get; set; }
    public JwtConfig JwtConfig { get; set; }
}
