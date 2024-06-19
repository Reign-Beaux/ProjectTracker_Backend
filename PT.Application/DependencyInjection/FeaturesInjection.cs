using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PT.Application.Features.Users;
using System.Reflection;

namespace PT.Application.DependencyInjection
{
    public static class FeaturesInjection
    {
        public static IServiceCollection AddFeaturesServices(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(assembly);

            var mapperConfig = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(new MappingUsers());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
