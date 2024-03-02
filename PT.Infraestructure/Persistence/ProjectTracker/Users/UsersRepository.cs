using PT.Infraestructure.Persistence.Common;
using System.Data;

namespace PT.Infraestructure.Persistence.ProjectTracker.Users
{
    public class UsersRepository : BaseRepository, IUsersRepository
    {
        public UsersRepository(IDbTransaction dbTransaction) : base(dbTransaction)
        {
        }
    }
}
