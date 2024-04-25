using Dapper;
using System.Data;

namespace PT.Infraestructure.Persistence.Common
{
    public class BaseRepository
    {
        protected readonly IDbTransaction _dbTransaction;
        protected readonly IDbConnection _dbConnection;

        public BaseRepository(IDbTransaction dbTransaction)
        {
            _dbTransaction = dbTransaction;
            _dbConnection = dbTransaction.Connection!;
        }

        public async Task<List<T>> GetAll<T>(string table)
        {
            var spString = $"[dbo].[usp_{table}_GET]";
            return (await _dbConnection.QueryAsync<T>(spString, transaction: _dbTransaction)).ToList();
        }

        public async Task<T> GetById<T>(string table, int id)
        {
            var spString = $"[dbo].[usp_{table}_GET]";
            return await _dbConnection.QuerySingleOrDefaultAsync<T>(spString, new { Id = id }, transaction: _dbTransaction);
        }

        public async Task Insert<T>(string table, T payload)
        {
            var spString = $"[dbo].[usp_{table}_INS]";
            await _dbConnection.ExecuteAsync(spString, payload, transaction: _dbTransaction);
        }

        public async Task Update<T>(string table, T payload)
        {
            var spString = $"[dbo].[usp_{table}_UPD]";
            await _dbConnection.ExecuteAsync(spString, payload, transaction: _dbTransaction);
        }

        public async Task Delete<T>(string table, int id)
        {
            var spString = $"[dbo].[usp_{table}_DEL]";
            await _dbConnection.ExecuteAsync(spString, new { Id = id }, transaction: _dbTransaction);
        }
    }
}
