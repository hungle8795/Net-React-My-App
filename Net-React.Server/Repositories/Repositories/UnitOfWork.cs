using Net_React.Server.Models;
using Net_React.Server.Repositories.Interface;
using Net_React.Server.Repositories.Interfaces;
using Net_React.Server.Repositories.Repository;

namespace Net_React.Server.Repositories.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceSampContext _context;
        public UnitOfWork(ECommerceSampContext context)
        {
            _context = context;
            Categories = new CategoryRepository(_context);
            ProductDetails = new ProductDetailRepository(_context);
        }
        public ICategoryRepository Categories { get; private set; }
        public IProductDetailRepository ProductDetails { get; private set; }
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
