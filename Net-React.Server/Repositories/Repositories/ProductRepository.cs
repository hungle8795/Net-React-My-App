using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;
using Net_React.Server.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace Net_React.Server.Repositories.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ECommerceSampContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Product>> GetAllByNameAsync(string name)
        {
            return await _context.Products.Where(n => n.Name == name).ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetAllByCategoryIdAsync(int categoryId)
        {
            return await _context.Products.Where(c => c.CategoryId == categoryId).ToListAsync();
        }
    }
}
