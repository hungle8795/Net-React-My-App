using Microsoft.AspNetCore.Mvc;
using Net_React.Server.Model;
using Net_React.Server.Repository;

namespace Net_React.Server.Controllers
{

    public class CategoryController
    {
        private readonly IRepository _repository;
        public CategoryController(IRepository repository)  
        {  
            this._repository = repository;
        }

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
