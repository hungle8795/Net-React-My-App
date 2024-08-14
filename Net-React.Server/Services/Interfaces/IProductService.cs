using Net_React.Server.DTOs;
using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;

namespace Net_React.Server.Services.Interfaces
{
    public interface IProductService 
    {
        Task<IEnumerable<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetProductById(int id);
        Task<ProductDTO> GetProductByName(string name);
        Task AddProduct(ProductDTO ProductDTO);
        Task UpdateProduct(ProductDTO ProductDTO);
        Task DeleteProduct(ProductDTO ProductDTO);
    }
}
