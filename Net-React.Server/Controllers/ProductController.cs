using Microsoft.AspNetCore.Mvc;
using Net_React.Server.DTOs;
using Net_React.Server.Models;
using Net_React.Server.Repositories.Interface;
using Net_React.Server.Services.Interfaces;
using Net_React.Server.Services.Services;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Net_React.Server.Controllers
{

    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productsDto = await _productService.GetAllProducts();
            return Ok(productsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productDto = await _productService.GetProductById(id);
            return productDto != null ? Ok(productDto) : NotFound();
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var productDto = await _productService.GetProductByName(name);
            return productDto == null ? NotFound() : Ok(productDto);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Add([FromBody] ProductDTO productDto)
        {
            await _productService.AddProduct(productDto);
            return CreatedAtAction("GetById", new { id = productDto.Id }, productDto);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] ProductDTO productDto)
        {
            await _productService.UpdateProduct(productDto);
            return Ok(productDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _productService.GetProductById(id);
            return NoContent();
        }
    }


}
