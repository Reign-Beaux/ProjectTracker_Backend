using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            return services;
        }
    }
}
