using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;
using Net_React.Server.Repositories.Repository;

namespace Net_React.Server.Repositories.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ECommerceSampContext context) : base(context)
        {
        }
        public Product GetByName(string name) => _context.Products.FirstOrDefault(n => n.Name == name);
    }
}
