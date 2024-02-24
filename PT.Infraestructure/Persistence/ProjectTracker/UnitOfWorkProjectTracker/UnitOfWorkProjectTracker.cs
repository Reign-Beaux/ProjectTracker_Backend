using Microsoft.Extensions.Configuration;
using PT.Infraestructure.Persistence.Common;
using PT.Infraestructure.Persistence.ProjectTracker.Roles;

namespace PT.Infraestructure.Persistence.ProjectTracker.UnitOfWorkProjectTracker
{
    public class UnitOfWorkProjectTracker : BaseUnitOfWork, IUnitOfWorkProjectTracker
    {
        public IRolesRepository RolesRepository { get; }

        public UnitOfWorkProjectTracker(IConfiguration configuration) : base(configuration["ConnectionStrings:ProjectTracker"]!)
        {
            RolesRepository = new RolesRepository(_dbTransaction);
        }
    }
}
