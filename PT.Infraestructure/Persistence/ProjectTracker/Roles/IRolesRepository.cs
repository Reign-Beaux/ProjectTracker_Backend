using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.Interfaces;
using PT.Infraestructure.Persistence.ProjectTracker.Roles.Models;

namespace PT.Infraestructure.Persistence.ProjectTracker.Roles
{
    public interface IRolesRepository : IRepository
    {
        Task<List<Role>> GetByFilters(RoleGetByFiltersPayload payload);
    }
}
