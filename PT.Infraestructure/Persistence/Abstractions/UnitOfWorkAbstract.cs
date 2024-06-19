using System.Data;
using System.Data.SqlClient;

namespace PT.Infraestructure.Persistence.Abstractions
{
    public abstract class UnitOfWorkAbstract
    {
        protected readonly IDbConnection _dbConnection;
        protected readonly IDbTransaction _dbTransaction;

        protected UnitOfWorkAbstract(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
            _dbConnection.Open();
            _dbTransaction = _dbConnection.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _dbTransaction.Commit();
            }
            catch (Exception)
            {
                _dbTransaction.Rollback();
            }
            finally
            {
                _dbTransaction.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            _dbTransaction?.Dispose();
            _dbConnection?.Dispose();
        }

        ~UnitOfWorkAbstract()
        {
            Dispose(false);
        }
    }
}
