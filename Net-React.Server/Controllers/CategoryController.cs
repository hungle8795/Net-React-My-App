using Microsoft.AspNetCore.Mvc;
using Net_React.Server.Models;
using Net_React.Server.Repositories.Interface;
using Net_React.Server.Services.Interfaces;
using Net_React.Server.Services.Services;

namespace Net_React.Server.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]

    public class CategoryController :  ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)  
        {  
            this._categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IList<Category>> GetAll()
        {
            return _categoryService.GetAllCategories();
        }

        //[HttpGet("id")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var model = _categoryService.GetByCategoryId(id);
            if (model == null) return NotFound();
            else return model;
        }

        [HttpGet("{name:string}")]
        public async Task<ActionResult<Category>> GetByName(string name)
        {
            var model = _categoryService.GetByCategoryName(name);
            if (model == null) return NotFound();
            else return model;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Add(Category category)
        {
            _categoryService.AddCategory(category);
            return CreatedAtAction("GetCategory", new { id =  category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Category category)
        {
            if (id != category.Id) return BadRequest();
            var model = _categoryService.GetByCategoryId(id);
            if (model == null) return NotFound();
            else
            {
                _categoryService.UpdateCategory(category);
                return Ok(category);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var model = _categoryService.GetByCategoryId(id);
            if (model == null)
            {
                return BadRequest();
            }
            else
            {
                _categoryService.DeleteByCategoryId(id);
                return Ok("Deleted " + id);
            }
        }
    }
}
