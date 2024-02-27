using PT.Infraestructure.Persistence.Common;
using System.Data;

namespace PT.Infraestructure.Persistence.ProjectTrackerTools.Logger
{
    public class LoggerRepository : BaseRepository, ILoggerRepository
    {
        public LoggerRepository(IDbTransaction dbTransaction) : base(dbTransaction)
        {
        }
    }
}
