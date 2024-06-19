using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.Interfaces;
using PT.Infraestructure.Persistence.ProjectTracker.Users.Models;

namespace PT.Infraestructure.Persistence.ProjectTracker.Users
{
    public interface IUsersRepository : IRepository
    {
        Task<User> GetByUsername(string username);
        Task<User> GetByEmail(string email);
        Task<List<User>> GetByFilters(UserGetByFiltersPayload payload);
    }
}
