using AutoMapper;
using Net_React.Server.Data;
using Net_React.Server.DTOs;
using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;
using Net_React.Server.Repositories.Repositories;
using Net_React.Server.Services.Interfaces;

namespace Net_React.Server.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.Repository<Product>().GetAllAsync();
            return _mapper.Map<List<ProductDTO>>(products);
        }
        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }
        public async Task<IEnumerable<ProductDTO>> GetAllProductByNameAsync(string name)
        {
            var productRepository = _unitOfWork.ProductRepository();
            var products = await productRepository.GetAllByNameAsync(name);
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
        
        public async Task<IEnumerable<ProductDTO>> GetAllProductByCategoryIdAsync(int categoryId)
        {
                var productRepository = _unitOfWork.ProductRepository();
                var products = await productRepository.GetAllByCategoryIdAsync(categoryId);
                return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
        public async Task AddProductAsync(ProductDTO productDto)
        {
            try
            {
                var product = _mapper.Map<Product>(productDto);
                await _unitOfWork.Repository<Product>().AddAsync(product);
                await _unitOfWork.CompleteAsync();
            }
            catch(Exception e)
            {
                var a = e.Message; 
            }
        }
        public async Task UpdateProductAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.CreatedAt = DateTime.Now;
            product.UpdatedAt = DateTime.Now;
            await _unitOfWork.Repository<Product>().UpdateAsync(product);
            await _unitOfWork.CompleteAsync();
        }
        public async Task DeleteProductAsync(int id)
        {
            await _unitOfWork.Repository<Product>().DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
