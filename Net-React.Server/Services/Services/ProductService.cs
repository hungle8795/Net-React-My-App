using AutoMapper;
using Azure;
using backend.Data;
using Net_React.Server.DTOs;
using Net_React.Server.DTOs.Product;
using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;
using Net_React.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Net_React.Server.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ProductService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// GetAllProducts
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<List<GetProductDTO>>> GetAllProducts()
        {
            var serviceResponse = new ServiceResponse<List<GetProductDTO>>();
            try
            {
                var dbProducts = await _context.Products.ToListAsync();
                serviceResponse.Data = dbProducts.Select(p => _mapper.Map<GetProductDTO>(p)).ToList();

                serviceResponse.Message = "Get Product successfully!";
            }
            catch (Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;

        }

        /// <summary>
        /// AddProduct
        /// </summary>
        /// <param name="newProduct"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<List<AddProductDTO>>> AddProduct(AddProductDTO newProduct)
        {
            var serviceResponse = new ServiceResponse<List<AddProductDTO>>();
            try
            {
                var product = _mapper.Map<Product>(newProduct);

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Products
                        .Select(p => _mapper.Map<AddProductDTO>(p))
                        .ToListAsync();

                serviceResponse.Message = "Product created successfully!";
            }
            catch (Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetProductDTO>>> DeleteProduct(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetProductDTO>>();

            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product is null)
                    throw new Exception($"Product with Id '{id}' not found.");

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Products.Select(p => _mapper.Map<GetProductDTO>(p)).ToListAsync();
                serviceResponse.Message = "Product deleted successfully!";
            }
            catch (Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        /// <summary>
        /// GetProductById: Get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<GetProductDTO>> GetProductById(int id)
        {
            var serviceResponse = new ServiceResponse<GetProductDTO>();
            try
            {
                var dbProduct = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);
                serviceResponse.Data = _mapper.Map<GetProductDTO>(dbProduct);
            }
            catch (Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
