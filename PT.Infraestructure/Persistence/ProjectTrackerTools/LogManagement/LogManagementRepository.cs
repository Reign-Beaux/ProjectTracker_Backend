using PT.Infraestructure.Persistence.Abstractions;
using System.Data;

namespace PT.Infraestructure.Persistence.ProjectTrackerTools.LogManagement
{
    public class LogManagementRepository : RepositoryAbstract, ILogManagementRepository
    {
        public LogManagementRepository(IDbTransaction dbTransaction) : base(dbTransaction)
        {
        }
    }
}
