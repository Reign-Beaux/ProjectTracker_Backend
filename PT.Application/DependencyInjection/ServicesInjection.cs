using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PT.Application.Features.Roles.Commands.RoleInsert;
using PT.Application.Services.LoggerService;

namespace PT.Application.DependencyInjection
{
    public static class ServicesInjection
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<LoggerService>();

            return services;
        }
    }
}
