using Microsoft.Extensions.Configuration;
using PT.Infraestructure.Persistence.Common;
using PT.Infraestructure.Persistence.ProjectTrackerTools.Logger;

namespace PT.Infraestructure.Persistence.ProjectTrackerTools.UnitOfWork
{
    public class UnitOfWorkProjectTrackerTools : BaseUnitOfWork, IUnitOfWorkProjectTrackerTools
    {
        public ILoggerRepository LoggerRepository { get; }

        public UnitOfWorkProjectTrackerTools(IConfiguration configuration) : base(configuration["ConnectionStrings:ProjectTrackerTools"]!)
        {
            LoggerRepository = new LoggerRepository(_dbTransaction);
        }
    }
}
