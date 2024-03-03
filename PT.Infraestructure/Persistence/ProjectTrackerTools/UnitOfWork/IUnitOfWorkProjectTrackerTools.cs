using PT.Infraestructure.Persistence.ProjectTrackerTools.LogManagement;

namespace PT.Infraestructure.Persistence.ProjectTrackerTools.UnitOfWork
{
    public interface IUnitOfWorkProjectTrackerTools
    {
        public ILogManagementRepository LogManagementRepository { get; }
        public void Commit();
    }
}
