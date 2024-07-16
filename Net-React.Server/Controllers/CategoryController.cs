using Net_React.Server.Models;
using Net_React.Server.Repositories.Interface;

namespace Net_React.Server.Controllers
{

    public class CategoryController
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)  
        {  
            this._categoryRepository = categoryRepository;
        }

        //public async Task<List<Category>> GetAll()
        //{
        //    var a = _categoryRepository.GetAll();
        //    return a;
        //}
        //[HttpGet]
        //public List<CategoryModel> GetAll()
        //{
        //    return _repository.GetAllCategory();
        //}

        //public async Task<CategoryModel> GetByName(string categoryName)
        //{
        //    return await _repository.GetByCategoryName(categoryName);
        //}
    }
}
