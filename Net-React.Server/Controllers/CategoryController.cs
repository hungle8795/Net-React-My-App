using Microsoft.AspNetCore.Mvc;
using Net_React.Server.Models;
using Net_React.Server.Repositories.Interface;
using Net_React.Server.Services.Interfaces;
using Net_React.Server.Services.Services;

namespace Net_React.Server.Controllers
{

    public class CategoryController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)  
        {  
            this._categoryService = categoryService;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return _categoryService.GetAll();
        }

        [HttpGet]
        public async Task<Category> GetByCategoryId(int id)
        {
            return _categoryService.GetById(id);
        }

        [HttpGet("name")]
        public async Task<Category> GetByCategoryName(string name)
        {
            return _categoryService.GetByName(name);
        }
        public async void AddCategory(Category category)
        {
            _categoryService.Add(category);
        }
        public async void UpdateCategory(Category category)
        {
            _categoryService.Update(category);
        }
        public async void DeleteById(int id)
        {
            _categoryService.Delete(id);
        }
    }
}
