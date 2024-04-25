using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.Common;

namespace PT.Infraestructure.Persistence.ProjectTracker.Users
{
    public interface IUsersRepository : IBaseRepository
    {
        Task<User> GetByUsername(string username);
        Task<User> GetByEmail(string email);
    }
}
