using Net_React.Server.Models;
using Net_React.Server.Repositories.Interface;
using Net_React.Server.Repositories.Interfaces;
using Net_React.Server.Services.Interfaces;

namespace Net_React.Server.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository, IRepository<Category> repository)
        {
            _categoryRepository = categoryRepository;
            _repository = repository;
        }
        public IEnumerable<Category> GetAll() => _repository.GetAll();
        public Category GetById(int id) => _repository.GetById(id);
        public Category GetByName(string name) => _categoryRepository.GetByName(name);
        public void AddCategory(Category category) => _repository.Add(category);
        public void UpdateCategory(Category category) => _repository.Update(category);
        public void DeleteById(int id) => _repository.Delete(id);
    }
}
