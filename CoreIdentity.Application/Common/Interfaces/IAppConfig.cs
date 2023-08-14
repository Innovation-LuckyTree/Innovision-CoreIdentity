using CoreIdentity.Application.Common.Models;

namespace CoreIdentity.Application.Common.Interfaces;

public interface IAppConfig
{
    public JwtConfig JwtConfig { get; set; }
}
