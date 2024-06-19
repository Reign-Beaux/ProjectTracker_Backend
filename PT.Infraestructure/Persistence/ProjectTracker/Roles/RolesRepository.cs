using PT.Infraestructure.Persistence.Abstractions;
using System.Data;

namespace PT.Infraestructure.Persistence.ProjectTracker.Roles
{
    public class RolesRepository : RepositoryAbstract, IRolesRepository
    {
        public RolesRepository(IDbTransaction dbTransaction) : base(dbTransaction)
        {
        }
    }
}
