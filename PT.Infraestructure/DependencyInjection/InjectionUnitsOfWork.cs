using Microsoft.Extensions.DependencyInjection;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWorkProjectTracker;

namespace PT.Infraestructure.DependencyInjection
{
    public static class InjectionUnitsOfWork
    {
        public static IServiceCollection AddInjectionUnitsOfWork(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWorkProjectTracker, UnitOfWorkProjectTracker>();

            return services;
        }
    }
}
