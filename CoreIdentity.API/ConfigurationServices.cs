using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Application.Common.Models;

namespace CoreIdentity.API;

public static class ConfigurationServices
{
    public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        var appConfig = configuration.GetSection("AppConfig").Get<AppConfig>();

        services.AddSingleton<IAppConfig>(appConfig);        

        return services;
    }
}
