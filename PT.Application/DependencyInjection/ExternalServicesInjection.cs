using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PT.Application.ExternalServices.WhatsApp;
using PT.Application.ExternalServices.WhatsApp.Models;

namespace PT.Application.DependencyInjection
{
    public static class ExternalServicesInjection
    {
        public static IServiceCollection AddExternalServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<WhatsAppService>();
            services.Configure<WhatsAppSettings>(configuration.GetSection("WhatsAppSettings"));

            return services;
        }
    }
}
