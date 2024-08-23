using Net_React.Server.DTOs.Product;
using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;

namespace Net_React.Server.Services.Interfaces
{
    public interface IProductService 
    {
        Task<ServiceResponse<List<GetProductDTO>>> GetAllProducts();
        Task<ServiceResponse<List<AddProductDTO>>> AddProduct(AddProductDTO newProduct);
        Task<ServiceResponse<List<GetProductDTO>>> DeleteProduct(int id);

        //Task<ProductDTO> GetProductByIdAsync(int id);
        //Task<ProductDTO> GetProductByNameAsync(string name);
        //Task AddProductAsync(ProductDTO ProductDTO);
        //Task UpdateProductAsync(ProductDTO ProductDTO);
        //Task DeleteProductAsync(int id);
    }
}
