using PT.Infraestructure.Persistence.ProjectTracker.Roles;

namespace PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork
{
    public interface IUnitOfWorkProjectTracker
    {
        public IRolesRepository RolesRepository { get; }
        public void Commit();
    }
}
