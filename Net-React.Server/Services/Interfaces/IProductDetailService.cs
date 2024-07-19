using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;

namespace Net_React.Server.Services.Interfaces
{
    public interface IProductDetailService 
    {
        IEnumerable<ProductDetail> GetAllProductDetails();
        ProductDetail GetByProductDetailName(string productName);
        ProductDetail GetByProductName(string name);
    }
}
