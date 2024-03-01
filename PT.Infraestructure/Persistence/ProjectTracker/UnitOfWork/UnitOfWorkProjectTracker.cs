using Microsoft.Extensions.Configuration;
using PT.Infraestructure.Persistence.Common;
using PT.Infraestructure.Persistence.ProjectTracker.Features;
using PT.Infraestructure.Persistence.ProjectTracker.Roles;

namespace PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork
{
    public class UnitOfWorkProjectTracker : BaseUnitOfWork, IUnitOfWorkProjectTracker
    {
        public IFeaturesRepository FeatureRepository { get; }
        public IRolesRepository RolesRepository { get; }

        public UnitOfWorkProjectTracker(IConfiguration configuration) : base(configuration["ConnectionStrings:ProjectTracker"]!)
        {
            FeatureRepository = new FeaturesRepository(_dbTransaction);
            RolesRepository = new RolesRepository(_dbTransaction);
        }
    }
}
