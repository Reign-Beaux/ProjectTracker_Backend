using Dapper;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.Abstractions;
using PT.Infraestructure.Persistence.ProjectTracker.Roles.Models;
using System.Data;

namespace PT.Infraestructure.Persistence.ProjectTracker.Roles
{
    public class RolesRepository : RepositoryAbstract, IRolesRepository
    {
        public RolesRepository(IDbTransaction dbTransaction) : base(dbTransaction)
        {
        }

        public async Task<List<Role>> GetByFilters(RoleGetByFiltersPayload payload)
        {
            var spString = "[dbo].[usp_Roles_GET_By_Filters]";
            return (await _dbConnection.QueryAsync<Role>(spString, payload, transaction: _dbTransaction)).ToList();
        }
    }
}
