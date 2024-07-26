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
            //var model = _productService.GetProductById(id);
            //if (model == null) return NotFound();
            //else return model;
            return _productService.GetProductById(id);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Product>> GetByName(string name)
        {
            //var model = _productService.GetProductByName(productName);
            //if(model == null) return NotFound();
            //else return model;
            return _productService.GetProductByName(name);
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddCategory(Product product)
        {
            _productService.AddProduct(product);
            //return CreatedAtAction("GetProduct", new { id = product.Id }, product);
            var mess = new MessageReport()
            {
                IsSuccess = true,
                Message = "New Record is added."
            };
            return mess.Message;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Update(int id, Product product)
        {
            //if (id != product.Id) return BadRequest();
            //var model = _productService.GetProductById(id);
            //if (model == null) return NotFound();
            //else
            //{
            //    _productService.UpdateProduct(product);
            //    return Ok(product);
            //}
            var model = _productService.GetProductById(id);
            if (model == null)
            {
                var mess = new MessageReport()
                {
                    IsSuccess = false,
                    Message = "Model is not exist."
                };
                return mess.Message;
            }
            else
            {
                _productService.UpdateProduct(product);
                var mess = new MessageReport()
                {
                    IsSuccess = true,
                    Message = "Model is updated."
                };
                return mess.Message;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteById(int id)
        {
            //var model = _productService.GetProductById(id);
            //if (model == null) return NotFound();
            //else
            //{
            //    _productService.DeleteProductById(id);
            //    return Ok("Deleted " + id);
            //}
            var model = _productService.GetProductById(id);
            if (model == null)
            {
                var mess = new MessageReport()
                {
                    IsSuccess = false,
                    Message = "Model is not exist."
                };
                return mess.Message;
            }
            else
            {
                _productService.DeleteProductById(id);
                var mess = new MessageReport()
                {
                    IsSuccess = true,
                    Message = "Model is deleted."
                };
                return mess.Message;
            }
        }
    }


}
