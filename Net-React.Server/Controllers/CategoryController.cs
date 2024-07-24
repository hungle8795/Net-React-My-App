using Microsoft.AspNetCore.Mvc;
using Net_React.Server.Models;
using Net_React.Server.Repositories.Interface;
using Net_React.Server.Services.Interfaces;
using Net_React.Server.Services.Services;

namespace Net_React.Server.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]

    public class CategoryController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)  
        {  
            this._categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetAll()
        {
            return _categoryService.GetAllCategories();
        }

        [HttpGet("id")]
        public async Task<Category> GetById(int id)
        {
            return _categoryService.GetByCategoryId(id);
        }

        [HttpGet("name")]
        public async Task<Category> GetByName(string name)
        {
            return _categoryService.GetByCategoryName(name);
        }

        [HttpPost]
        public async Task<string> Add(Category category)
        {
            _categoryService.AddCategory(category);
            var mess = new MessageReport()
            {
                IsSuccess = true,
                Message = "New Record is added."
            };
            return mess.Message;
        }

        [HttpPut("id")]
        public async Task<string> Update(int id, Category category)
        {
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

        [HttpDelete("id")]
        public async Task<string> DeleteById(int id)
        {
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
