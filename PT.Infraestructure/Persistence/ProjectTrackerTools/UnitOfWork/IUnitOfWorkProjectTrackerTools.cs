using PT.Infraestructure.Persistence.ProjectTrackerTools.Logger;

namespace PT.Infraestructure.Persistence.ProjectTrackerTools.UnitOfWork
{
    public interface IUnitOfWorkProjectTrackerTools
    {
        public ILoggerRepository LoggerRepository { get; }
        public void Commit();
    }
}
