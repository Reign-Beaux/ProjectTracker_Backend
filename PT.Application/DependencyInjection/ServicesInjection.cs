using Microsoft.Extensions.DependencyInjection;
using PT.Application.Services.ResponseManagement;

namespace PT.Application.DependencyInjection
{
    public static class ServicesInjection
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<ResponseManagementService>();

            return services;
        }
    }
}
