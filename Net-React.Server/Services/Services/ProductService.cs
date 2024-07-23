using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;
using Net_React.Server.Repositories.Repositories;
using Net_React.Server.Services.Interfaces;

namespace Net_React.Server.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IEnumerable<Product> GetAllProducts() => _productRepository.GetAll();
        public Product GetProductById(int id) => _productRepository.GetById(id);
        public Product GetProductByName(string name) => _productRepository.GetByName(name);
        public void AddProduct(Product product) => _productRepository.Add(product);
        public void UpdateProduct(Product product) => _productRepository.Update(product);
        public void DeleteProductById(int id) => _productRepository.Delete(id);
    }
}
