using PT.Infraestructure.Persistence.Common;
using System.Data;

namespace PT.Infraestructure.Persistence.ProjectTrackerTools.LogManagement
{
    public class LogManagementRepository : BaseRepository, ILogManagementRepository
    {
        public LogManagementRepository(IDbTransaction dbTransaction) : base(dbTransaction)
        {
        }
    }
}
