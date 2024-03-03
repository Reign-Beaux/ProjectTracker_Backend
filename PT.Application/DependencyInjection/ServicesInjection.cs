using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PT.Application.Services.Email;
using PT.Application.Services.Email.Models;
using PT.Application.Services.LoggerManagement;
using PT.Application.Services.ResponseManagement;
using PT.Application.Services.WhatsApp;
using PT.Application.Services.WhatsApp.Models;

namespace PT.Application.DependencyInjection
{
    public static class ServicesInjection
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<EmailService>();
            services.AddTransient<LoggerManagementService>();
            services.AddTransient<ResponseManagementService>();
            services.AddTransient<WhatsAppService>();

            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.Configure<WhatsAppSettings>(configuration.GetSection("WhatsAppSettings"));
            return services;
        }
    }
}
