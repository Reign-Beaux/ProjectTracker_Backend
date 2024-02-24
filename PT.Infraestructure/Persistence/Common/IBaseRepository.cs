namespace PT.Infraestructure.Persistence.Common
{
    public interface IBaseRepository
    {
        Task<List<T>> GetAll<T>();
        Task<T?> GetById<T>(int id);
        Task Insert<T>(T payload);
        Task Update<T>(T payload);
        Task Delete<T>(int id);
    }
}
