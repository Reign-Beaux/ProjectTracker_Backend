namespace PT.Infraestructure.Persistence.Common
{
    public interface IBaseRepository
    {
        Task<List<T>> GetAll<T>();
        Task<T?> GetById<T>(int id);
        Task Insert<T, U>(U payload);
        Task Update<T>(T payload);
        Task Delete<T>(int id);
    }
}
