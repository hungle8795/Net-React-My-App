using Microsoft.AspNetCore.Mvc;
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
        public async Task<IList<Product>> GetAll()
        {
            return _productService.GetAllProducts();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var model = _productService.GetProductById(id);
            if (model == null) return NotFound();
            else return model;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Product>> GetByName(string name)
        {
            var model = _productService.GetProductByName(name);
            if (model == null) return NotFound();
            else return model;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Product>> AddCategory(Product product)
        {
            _productService.AddProduct(product);
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if (id != product.Id) return BadRequest();
            var model = _productService.GetProductById(id);
            if (model == null) return NotFound();
            else
            {
                model.Price = product.Price;
                model.Name = product.Name;
                model.Quantity = product.Quantity;
                model.Category = product.Category;
                model.CategoryId = product.CategoryId;
                model.Id = product.Id;
                model.CreatedAt = DateTime.Now;
                model.UpdatedAt = DateTime.Now;
                model.Description = product.Description;
                _productService.UpdateProduct(model);
                return Ok(product);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var model = _productService.GetProductById(id);
            if (model == null) return NotFound();
            else
            {
                _productService.DeleteProductById(id);
                return Ok("Deleted " + id);
            }
        }
    }


}
