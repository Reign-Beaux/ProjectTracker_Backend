using Microsoft.Extensions.DependencyInjection;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;
using PT.Infraestructure.Persistence.ProjectTrackerTools.UnitOfWork;

namespace PT.Infraestructure.DependencyInjection
{
    public static class InjectionUnitsOfWork
    {
        public static IServiceCollection AddUnitsOfWorkServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWorkProjectTracker, UnitOfWorkProjectTracker>();
            services.AddTransient<IUnitOfWorkProjectTrackerTools, UnitOfWorkProjectTrackerTools>();

            return services;
        }
    }
}
