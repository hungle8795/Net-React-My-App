using Net_React.Server.DTOs;
using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;

namespace Net_React.Server.Services.Interfaces
{
    public interface IProductService 
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductDTO>> GetAllProductByNameAsync(string name); 
        Task<IEnumerable<ProductDTO>> GetAllProductByCategoryIdAsync(int categoryId);
        Task AddProductAsync(ProductDTO ProductDTO);
        Task UpdateProductAsync(ProductDTO ProductDTO);
        Task DeleteProductAsync(int id);
    }
}
