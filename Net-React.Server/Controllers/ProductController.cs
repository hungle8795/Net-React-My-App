using Microsoft.AspNetCore.Mvc;
using Net_React.Server.Models;
using Net_React.Server.Repositories.Interface;
using Net_React.Server.Services.Interfaces;
using Net_React.Server.Services.Services;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Net_React.Server.Controllers
{

    [Route("api/products")]
    public class ProductController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAll()
        {
            return _productService.GetAllProducts();
        }
        public async Task<Product> GetById(int id)
        {
            return _productService.GetProductById(id);
        }
        [HttpGet("name")]
        public async Task<Product> GetByName(string productName)
        {
            return _productService.GetProductByName(productName);
        }
        public async void AddCategory(Product product)
        {
            _productService.AddProduct(product);
        }
        public async void UpdateCategory(Product productDetai)
        {
            _productService.UpdateProduct(productDetai);
        }
        public async void DeleteById(int id)
        {
            _productService.DeleteProductById(id);
        }
    }


}
