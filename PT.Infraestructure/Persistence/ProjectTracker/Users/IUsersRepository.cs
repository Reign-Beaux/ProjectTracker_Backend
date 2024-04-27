using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.Common;
using PT.Infraestructure.Persistence.ProjectTracker.Users.Models;

namespace PT.Infraestructure.Persistence.ProjectTracker.Users
{
    public interface IUsersRepository : IBaseRepository
    {
        Task<User> GetByUsername(string username);
        Task<User> GetByEmail(string email);
        Task<List<User>> GetByFilters(GetByFiltersPayload payload);
    }
}
