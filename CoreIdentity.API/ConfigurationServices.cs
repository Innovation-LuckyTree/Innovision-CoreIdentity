using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Application.Common.Models;

namespace CoreIdentity.API;

public static class ConfigurationServices
{
    public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtConfig = configuration.GetSection("AppConfig:Jwt").Get<JwtConfig>();

        var appConfig = new AppConfig
        {
            JwtConfig = jwtConfig
        };

        services.AddSingleton<IAppConfig>(appConfig);        

        return services;
    }
}
