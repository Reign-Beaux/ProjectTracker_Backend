﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PT.Application.Behaviors;

namespace PT.Application.DependencyInjection
{
    public static class BehaviorsInjection
    {
        public static IServiceCollection AddBehaviorsServices(this IServiceCollection services)
        {

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
