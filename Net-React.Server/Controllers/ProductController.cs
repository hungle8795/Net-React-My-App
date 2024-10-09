using Microsoft.AspNetCore.Mvc;
using Net_React.Server.DTOs;
using Net_React.Server.Services.Interfaces;

namespace Net_React.Server.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly string _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "productImages");
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productsDto = await _productService.GetAllProductsAsync();
            return Ok(productsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productDto = await _productService.GetProductByIdAsync(id);
            return productDto != null ? Ok(productDto) : NotFound();
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var productDto = await _productService.GetAllProductByNameAsync(name);
            return productDto == null ? NotFound() : Ok(productDto);
        }

        [HttpGet("categoryId/{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            var productDto = await _productService.GetAllProductByCategoryIdAsync(categoryId);
            return productDto == null ? NotFound() : Ok(productDto);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post(IFormFile image, [FromForm] int id, [FromForm] string name,
            [FromForm] int price, [FromForm] int quantity, 
            [FromForm] int categoryId, [FromForm] string description)
        {
            if (!Directory.Exists(_storagePath))
            {
                Directory.CreateDirectory(_storagePath);
            }
            if(image == null || image.Length == 0 || image == null)
            {
                return BadRequest("Invalid.");
            }

            var fileName = Path.GetFileName(image.FileName);
            var filePath = Path.Combine(_storagePath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }
            var productDto = new ProductDTO();
            productDto.Id = id;
            productDto.Name = name;
            productDto.Image = fileName;
            productDto.Quantity = quantity;
            productDto.Price = price;
            productDto.CategoryId = categoryId;
            productDto.Description = description;
            await _productService.AddProductAsync(productDto);
            return CreatedAtAction(nameof(GetById), new { id = productDto.Id }, productDto);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] ProductDTO productDto)
        {
            await _productService.UpdateProductAsync(productDto);
            return Ok(productDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var productDto = await _productService.GetProductByIdAsync(id);
            var fileName = Path.GetFileName(productDto.Image);
            var filePath = Path.Combine(_storagePath, fileName);
            if(!System.IO.File.Exists(filePath))
            {
                return NotFound("Not found image");
            } 
            await _productService.DeleteProductAsync(id);
            System.IO.File.Delete(filePath);
            return NoContent();
        }
    }
}
