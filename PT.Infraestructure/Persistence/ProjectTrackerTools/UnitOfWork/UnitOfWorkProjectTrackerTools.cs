using Microsoft.Extensions.Configuration;
using PT.Infraestructure.Persistence.Abstractions;
using PT.Infraestructure.Persistence.ProjectTrackerTools.LogManagement;

namespace PT.Infraestructure.Persistence.ProjectTrackerTools.UnitOfWork
{
    public class UnitOfWorkProjectTrackerTools : UnitOfWorkAbstract, IUnitOfWorkProjectTrackerTools
    {
        public ILogManagementRepository LogManagementRepository { get; }

        public UnitOfWorkProjectTrackerTools(IConfiguration configuration) : base(configuration["ConnectionStrings:ProjectTrackerTools"]!)
        {
            LogManagementRepository = new LogManagementRepository(_dbTransaction);
        }
    }
}
