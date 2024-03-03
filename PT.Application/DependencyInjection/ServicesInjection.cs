using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PT.Application.ExternalServices.WhatsApp;
using PT.Application.ExternalServices.WhatsApp.Models;
using PT.Application.Services.Email;
using PT.Application.Services.Email.Models;
using PT.Application.Services.Logger;

namespace PT.Application.DependencyInjection
{
    public static class ServicesInjection
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<EmailService>();
            services.AddTransient<LogManagementService>();
            services.AddTransient<WhatsAppService>();

            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.Configure<WhatsAppSettings>(configuration.GetSection("WhatsAppSettings"));
            return services;
        }
    }
}
