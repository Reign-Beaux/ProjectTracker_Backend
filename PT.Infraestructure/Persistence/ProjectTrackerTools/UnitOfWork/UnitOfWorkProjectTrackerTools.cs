using Microsoft.Extensions.Configuration;
using PT.Infraestructure.Persistence.Common;
using PT.Infraestructure.Persistence.ProjectTrackerTools.LogManagement;

namespace PT.Infraestructure.Persistence.ProjectTrackerTools.UnitOfWork
{
    public class UnitOfWorkProjectTrackerTools : BaseUnitOfWork, IUnitOfWorkProjectTrackerTools
    {
        public ILogManagementRepository LogManagementRepository { get; }

        public UnitOfWorkProjectTrackerTools(IConfiguration configuration) : base(configuration["ConnectionStrings:ProjectTrackerTools"]!)
        {
            LogManagementRepository = new LogManagementRepository(_dbTransaction);
        }
    }
}
