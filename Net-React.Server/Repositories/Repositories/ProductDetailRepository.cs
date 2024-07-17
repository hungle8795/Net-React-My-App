using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;
using Net_React.Server.Repositories.Repository;

namespace Net_React.Server.Repositories.Repositories
{
    public class ProductDetailRepository : Repository<ProductDetail>, IProductDetailRepository
    {
        public ProductDetailRepository(ECommerceSampContext context) : base(context)
        {
        }
        public ProductDetail GetByName(string name) => _context.ProductDetails.FirstOrDefault(n => n.Name == name);
    }
}
