using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PT.Application.Models.Settings;

namespace PT.Application.DependencyInjection
{
    public static class SettingsInjection
    {
        public static IServiceCollection AddSettingsInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            return services;
        }
    }
}
