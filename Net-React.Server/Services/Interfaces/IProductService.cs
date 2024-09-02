using Net_React.Server.DTOs.Product;
using backend.Models;
using Net_React.Server.DTOs.General;
using System.Security.Claims;
namespace Net_React.Server.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<GetProductDTO>> GetAllProducts();
        Task<ServiceResponse<List<GetProductDTO>>> DeleteProduct(int id);
        Task<ServiceResponse<List<AddProductDTO>>> AddNewProduct(ClaimsPrincipal User, AddProductDTO newProduct, IFormFile image);

        //Task<ProductDTO> GetProductByIdAsync(int id);
        //Task<ProductDTO> GetProductByNameAsync(string name);
        //Task AddProductAsync(ProductDTO ProductDTO);
        //Task UpdateProductAsync(ProductDTO ProductDTO);
        //Task DeleteProductAsync(int id);
    }
}

