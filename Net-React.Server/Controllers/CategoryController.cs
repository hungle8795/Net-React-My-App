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
            return _categoryService.GetAllCategories();
        }

        [HttpGet]
        public async Task<Category> GetById(int id)
        {
            return _categoryService.GetByCategoryId(id);
        }

        [HttpGet("name")]
        public async Task<Category> GetByName(string name)
        {
            return _categoryService.GetByCategoryName(name);
        }
        public async void Add(Category category)
        {
            _categoryService.AddCategory(category);
        }
        public async void Update(Category category)
        {
            _categoryService.UpdateCategory(category);
        }
        public async void DeleteById(int id)
        {
            _categoryService.DeleteByCategoryId(id);
        }
    }
}
