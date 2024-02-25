using Dapper;
using System.Data;

namespace PT.Infraestructure.Persistence.Common
{
    public class BaseRepository
    {
        private readonly IDbTransaction _dbTransaction;
        private readonly IDbConnection _dbConnection;

        public BaseRepository(IDbTransaction dbTransaction)
        {
            _dbTransaction = dbTransaction;
            _dbConnection = dbTransaction.Connection!;
        }

        public async Task<List<T>> GetAll<T>()
        {
            var entity = typeof(T);
            var spString = $"[dbo].[usp_{entity}s_GET]";
            return (await _dbConnection.QueryAsync<T>(spString, transaction: _dbTransaction)).ToList();
        }

        public async Task<T?> GetById<T>(int id)
        {
            var entity = typeof(T);
            var spString = $"[dbo].[usp_{entity}s_GET] @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<T>(spString, new { Id = id }, transaction: _dbTransaction);
        }

        public async Task Insert<T, U>(U payload)
        {
            var entity = typeof(T);
            var spString = $"[dbo].[usp_{entity.Name}s_INS]";
            await _dbConnection.ExecuteAsync(spString, payload, transaction: _dbTransaction);
        }

        public async Task Update<T>(T payload)
        {
            var entity = typeof(T);
            var spString = $"[dbo].[usp_{entity}s_UPD]";
            await _dbConnection.ExecuteAsync(spString, payload, transaction: _dbTransaction);
        }

        public async Task Delete<T>(int id)
        {
            var entity = typeof(T);
            var spString = $"[dbo].[usp_{entity}s_DEL]";
            await _dbConnection.ExecuteAsync(spString, new { Id = id }, transaction: _dbTransaction);
        }
    }
}
