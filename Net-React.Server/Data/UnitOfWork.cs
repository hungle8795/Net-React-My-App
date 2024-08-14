using Net_React.Server.Models;
using Net_React.Server.Repositories.Interface;
using Net_React.Server.Repositories.Interfaces;
using Net_React.Server.Repositories.Repositories;
using Net_React.Server.Repositories.Repository;

namespace Net_React.Server.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceSampContext _context;
        private readonly Dictionary<Type, object> _repositories = new();
        public UnitOfWork(ECommerceSampContext context)
        {
            _context = context;
        }
        public IRepository<T> Repository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IRepository<T>)_repositories[typeof(T)];
            }

            var repository = new Repository<T>(_context);
            _repositories.Add(typeof(T), repository);
            return repository;
        }
        public ICategoryRepository CategoryRepository()
        {
            return (ICategoryRepository)Repository<Category>();
        }
        public IProductRepository ProductRepository()
        {
            return (IProductRepository)Repository<Product>();
        }
        public IAddressRepository AddressRepository()
        {
            return (IAddressRepository)Repository<Address>();
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
