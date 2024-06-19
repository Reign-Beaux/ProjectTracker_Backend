using Dapper;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.Abstractions;
using PT.Infraestructure.Persistence.ProjectTracker.Users.Models;
using System.Data;

namespace PT.Infraestructure.Persistence.ProjectTracker.Users
{
    public class UsersRepository : RepositoryAbstract, IUsersRepository
    {
        public UsersRepository(IDbTransaction dbTransaction) : base(dbTransaction)
        {
        }

        public async Task<User> GetByUsername(string username)
        {
            var spString = "[dbo].[usp_Users_GET] @UserName = @UserName";
            return await _dbConnection.QuerySingleOrDefaultAsync<User>(spString, new { UserName = username }, transaction: _dbTransaction);
        }

        public async Task<User> GetByEmail(string email)
        {
            var spString = "[dbo].[usp_Users_GET] @Email = @Email";
            return await _dbConnection.QuerySingleOrDefaultAsync<User>(spString, new { Email = email }, transaction: _dbTransaction);
        }

        public async Task<List<User>> GetByFilters(UserGetByFiltersPayload payload)
        {
            var spString = "[dbo].[usp_Users_GET_By_Filters] @UserName, @Name, @PaternalLastname, @MaternalLastname, @Email, @PageSize, @PageNumber, @OrderBy, @SortDirection";
            return (await _dbConnection.QueryAsync<User>(spString, payload, transaction: _dbTransaction)).ToList();
        }
    }
}
