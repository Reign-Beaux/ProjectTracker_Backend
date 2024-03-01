using PT.Infraestructure.Persistence.ProjectTracker.Features;
using PT.Infraestructure.Persistence.ProjectTracker.Roles;

namespace PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork
{
    public interface IUnitOfWorkProjectTracker
    {
        public IFeaturesRepository FeatureRepository { get; }
        public IRolesRepository RolesRepository { get; }
        public void Commit();
    }
}
