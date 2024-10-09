using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net_React.Server.DTOs;
using Net_React.Server.Services.Interfaces;

namespace Net_React.Server.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly string _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "categoryImages");
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
        public async Task<IActionResult> Post(IFormFile image, [FromForm] string name, 
            [FromForm] int id, [FromForm] string description)
        {
            if (!Directory.Exists(_storagePath))
            {
                Directory.CreateDirectory(_storagePath);
            }
            if (image == null || image.Length == 0 || image == null)
            {
                return BadRequest("Invalid.");
            }

            var fileName = Path.GetFileName(image.FileName);
            var filePath = Path.Combine(_storagePath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }
            var categoryDto = new CategoryDTO();
            categoryDto.Name = name;
            categoryDto.Description = description;
            categoryDto.Id = id;
            categoryDto.Image = fileName;
            await _categoryService.AddCategoryAsync(categoryDto);
            return CreatedAtAction(nameof(GetById), new { id = categoryDto.Id }, categoryDto);
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
            var categoryDto = await _categoryService.GetCategoryByIdAsync(id);
            var fileName = Path.GetFileName(categoryDto.Image);
            var filePath = Path.Combine(_storagePath, fileName);
            var check = System.IO.File.Exists(filePath);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("Not found image.");
            }
            await _categoryService.DeleteCategoryAsync(id);
            System.IO.File.Delete(filePath);
            return NoContent();
        }
    }
}
