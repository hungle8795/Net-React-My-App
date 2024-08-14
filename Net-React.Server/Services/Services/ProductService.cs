using AutoMapper;
using Net_React.Server.DTOs;
using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;
using Net_React.Server.Repositories.Repositories;
using Net_React.Server.Services.Interfaces;

namespace Net_React.Server.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<List<ProductDTO>>(products);
        }
        public async Task<ProductDTO> GetProductById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return null;
            var productDto = _mapper.Map<ProductDTO>(product);
            return productDto;
        }
        public async Task<ProductDTO> GetProductByName(string name)
        {
            var product = await _productRepository.GetByNameAsync(name);
            if (product == null) return null;
            var productDto = _mapper.Map<ProductDTO>(product);
            return productDto;
        }
        public async Task AddProduct(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.AddAsync(product);
        }
        public async Task UpdateProduct(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.CreatedAt = DateTime.Now;
            product.UpdatedAt = DateTime.Now;
            await _productRepository.UpdateAsync(product);
        }
        public async Task DeleteProduct(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.Remove(product);
        }
    }
}
