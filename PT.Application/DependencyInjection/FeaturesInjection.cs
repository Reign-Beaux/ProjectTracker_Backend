using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PT.Application.Features.Auth.Commands.Login.Models;
using System.Reflection;

namespace PT.Application.DependencyInjection
{
    public static class FeaturesInjection
    {
        public static IServiceCollection AddFeaturesServices(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(assembly);

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            return services;
        }
    }
}
