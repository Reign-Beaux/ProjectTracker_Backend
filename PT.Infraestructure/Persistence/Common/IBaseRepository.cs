namespace PT.Infraestructure.Persistence.Common
{
    public interface IBaseRepository
    {
        Task<List<T>> GetAll<T>(string table);
        Task<T?> GetById<T>(string table, int id);
        Task Insert<T>(string table, T payload);
        Task Update<T>(string table, T payload);
        Task Delete<T>(string table, int id);
    }
}
