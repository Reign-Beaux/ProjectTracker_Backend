using PT.Infraestructure.Persistence.ProjectTracker.Roles;

namespace PT.Infraestructure.Persistence.ProjectTracker.UnitOfWorkProjectTracker
{
    public interface IUnitOfWorkProjectTracker
    {
        public IRolesRepository RolesRepository { get; }
        public void Commit();
    }
}
