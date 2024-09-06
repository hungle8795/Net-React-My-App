using Net_React.Server.DTOs;
using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;

namespace Net_React.Server.Services.Interfaces
{
    public interface IProductService 
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(int id);
        Task<ProductDTO> GetProductByNameAsync(string name); 
        Task<List<ProductDTO>> GetProductByCategoryIdAsync(int categoryId);
        Task AddProductAsync(ProductDTO ProductDTO);
        Task UpdateProductAsync(ProductDTO ProductDTO);
        Task DeleteProductAsync(int id);
    }
}
