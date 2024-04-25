using Dapper;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.Common;
using System.Data;

namespace PT.Infraestructure.Persistence.ProjectTracker.Users
{
    public class UsersRepository : BaseRepository, IUsersRepository
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
    }
}
