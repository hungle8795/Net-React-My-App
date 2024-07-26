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
            //var model = _categoryService.GetByCategoryId(id);
            //if (model == null) return NotFound();
            //else return model;
            return _categoryService.GetByCategoryId(id);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Category>> GetByName(string name)
        {
            //var model = _categoryService.GetByCategoryName(name);
            //if (model == null) return NotFound();
            //else return model;
            return _categoryService.GetByCategoryName(name);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Add(Category category)
        {
            _categoryService.AddCategory(category);
            //return CreatedAtAction("GetCategory", new { id =  category.Id }, category);
            var mess = new MessageReport()
            {
                IsSuccess = true,
                Message = "New Record is added."
            };
            return mess.Message;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Update(int id, Category category)
        {
            //if (id != category.Id) return BadRequest();
            //var model = _categoryService.GetByCategoryId(id);
            //if (model == null) return NotFound();
            //else
            //{
            //    _categoryService.UpdateCategory(category);
            //    return Ok(category);
            //}
            var model = _categoryService.GetByCategoryId(id);
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
                _categoryService.UpdateCategory(category);
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
            //var model = _categoryService.GetByCategoryId(id);
            //if (model == null)
            //{
            //    return BadRequest();
            //}
            //else
            //{
            //    _categoryService.DeleteByCategoryId(id);
            //    return Ok("Deleted " + id);
            //}
            var model = _categoryService.GetByCategoryId(id);
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
                _categoryService.DeleteByCategoryId(id);
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
