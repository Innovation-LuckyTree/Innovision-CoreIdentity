using CoreIdentity.Application.Common.Interfaces;

namespace CoreIdentity.Application.Common.Models;

public class AppConfig : IAppConfig
{
    public JwtConfig JwtConfig { get; set; }
}