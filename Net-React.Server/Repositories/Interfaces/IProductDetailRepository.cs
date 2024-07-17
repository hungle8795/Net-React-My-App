using Net_React.Server.Models;

namespace Net_React.Server.Repositories.Interfaces
{
    public interface IProductDetailRepository : IRepository<ProductDetail>
    {
        ProductDetail GetByName(string name);
    }
}
