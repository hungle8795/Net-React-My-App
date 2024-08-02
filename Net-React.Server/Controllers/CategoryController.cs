using Microsoft.AspNetCore.Mvc;
using Net_React.Server.DTOs;
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
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }

        //[HttpGet("id")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> GetById(int id)
        {
            var model = await _categoryService.GetCategoryById(id);
            if (model == null) return NotFound();
            return await model;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<CategoryDTO>> GetByName(string name)
        {
            var model = await _categoryService.GetCategoryByName(name);
            if (model == null) return NotFound();
            return await model;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Add(CategoryDTO category)
        {
            await _categoryService.AddCategory(category);
            return CreatedAtAction("GetCategory", new { id =  category.Id }, category);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, CategoryDTO category)
        {
            if (id != category.Id) return BadRequest();
            var model = _categoryService.GetCategoryById(id);
            if (model == null) return NotFound();
            else
            {
                model.Name = category.Name;
                model.Description = category.Description;
                _categoryService.UpdateCategory(model);
                return Ok(category);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var model = _categoryService.GetCategoryById(id);
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
