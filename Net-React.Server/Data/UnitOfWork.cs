using Net_React.Server.Models;
using Net_React.Server.Repositories.Interface;
using Net_React.Server.Repositories.Interfaces;
using Net_React.Server.Repositories.Repositories;
using Net_React.Server.Repositories.Repository;

namespace Net_React.Server.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcommerceSampContext _context;
        private readonly Dictionary<Type, object> _repositories = new();
        public UnitOfWork(EcommerceSampContext context)
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
            var categoryRepository = new CategoryRepository(_context);
            _repositories.Add(typeof(Category), categoryRepository);
            return categoryRepository;
        }
        public IProductRepository ProductRepository()
        {
            var productRepository = new ProductRepository(_context);
            _repositories.Add(typeof(Product), productRepository);
            return productRepository;
        }
        public IAddressRepository AddressRepository()
        {
            var addressRepository = new AddressRepository(_context);
            _repositories.Add(typeof(Address), addressRepository);
            return addressRepository;
        }
        public IUserRepository UserRepository()
        {
            var userRepository = new UserRepository(_context);
            _repositories.Add(typeof(User), userRepository);
            return userRepository;
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
