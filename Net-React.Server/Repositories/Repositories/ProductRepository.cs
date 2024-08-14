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
        public async Task<Product> GetByNameAsync(string name)
        {
            return await _context.Set<Product>()
            .FirstOrDefaultAsync(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
