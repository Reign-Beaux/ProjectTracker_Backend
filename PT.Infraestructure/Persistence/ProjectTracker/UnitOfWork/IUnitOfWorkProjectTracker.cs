using PT.Infraestructure.Persistence.ProjectTracker.Features;
using PT.Infraestructure.Persistence.ProjectTracker.Roles;
using PT.Infraestructure.Persistence.ProjectTracker.Users;

namespace PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork
{
    public interface IUnitOfWorkProjectTracker
    {
        public IFeaturesRepository FeatureRepository { get; }
        public IRolesRepository RolesRepository { get; }
        public IUsersRepository UsersRepository { get; }
        public void Commit();
    }
}
