using Net_React.Server.Repositories.Interface;
using Net_React.Server.Repositories.Interfaces;

namespace Net_React.Server.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class;
        ICategoryRepository CategoryRepository();
        IProductRepository ProductRepository();
        IAddressRepository AddressRepository();
        Task<int> CompleteAsync();
        void Dispose();
    }
}
