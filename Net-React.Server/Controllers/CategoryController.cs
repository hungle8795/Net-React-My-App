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

    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categoriesDto = await _categoryService.GetAllCategoriesAsync();
            return Ok(categoriesDto);
        }

        //[HttpGet("id")]
        [HttpGet("id/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoryDto = await _categoryService.GetCategoryByIdAsync(id);
            return categoryDto == null ? NotFound() : Ok(categoryDto);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult> GetByName(string name)
        {
            var categoryDto = await _categoryService.GetCategoryByNameAsync(name);
            return categoryDto == null ? NotFound() : Ok(categoryDto);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] CategoryDTO categoryDto)
        {
            await _categoryService.AddCategoryAsync(categoryDto);   
            return CreatedAtAction(nameof(GetById), new {id = categoryDto.Id }, categoryDto);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] CategoryDTO categoryDto)
        {
            await _categoryService.UpdateCategoryAsync(categoryDto);
            return Ok(categoryDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
