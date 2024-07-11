using Net_React.Server.Repository.Interface;

namespace Net_React.Server.Repositories.Interface
{
    public class ICategoryRepository : IRepository
    {
        public Task<T> Create<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
