using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;

namespace Net_React.Server.Services.Interfaces
{
    public interface IProductService 
    {
        IList<Product> GetAllProducts();
        Product GetProductById(int id);
        Product GetProductByName(string productName);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProductById(int id);
    }
}
