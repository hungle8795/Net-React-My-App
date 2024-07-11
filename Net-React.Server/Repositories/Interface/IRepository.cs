namespace Net_React.Server.Repository.Interface
{
    public interface IRepository
    {
        //Task<List<T>> GetAll();
        Task<T> Create<T>(T entity);
        Task<T> Update<T>(T entity);
        Task Delete<T>(T entity);
    }
}
