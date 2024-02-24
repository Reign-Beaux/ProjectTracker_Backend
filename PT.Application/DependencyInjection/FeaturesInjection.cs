using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PT.Application.DependencyInjection
{
    public static class FeaturesInjection
    {
        public static IServiceCollection AddFeaturesServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(assembly);

            return services;
        }
    }
}
