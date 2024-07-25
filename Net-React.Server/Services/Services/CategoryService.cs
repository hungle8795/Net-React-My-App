using Net_React.Server.Models;
using Net_React.Server.Repositories.Interface;
using Net_React.Server.Services.Interfaces;

namespace Net_React.Server.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IList<Category> GetAllCategories() => _categoryRepository.GetAll();
        public Category GetByCategoryId(int id) => _categoryRepository.GetById(id);
        public Category GetByCategoryName(string name) => _categoryRepository.GetByName(name);
        public void AddCategory(Category category) => _categoryRepository.Add(category);
        public void UpdateCategory(Category category) => _categoryRepository.Update(category);
        public void DeleteByCategoryId(int id) => _categoryRepository.Delete(id);
    }
}
