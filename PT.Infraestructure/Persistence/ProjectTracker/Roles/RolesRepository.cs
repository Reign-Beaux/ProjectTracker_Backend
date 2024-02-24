using PT.Infraestructure.Persistence.Common;
using System.Data;

namespace PT.Infraestructure.Persistence.ProjectTracker.Roles
{
    public class RolesRepository : BaseRepository, IRolesRepository
    {
        public RolesRepository(IDbTransaction dbTransaction) : base(dbTransaction)
        {
        }
    }
}
