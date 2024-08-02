using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Net_React.Server.DTOs;
using Net_React.Server.Models;
using Net_React.Server.Repositories.Interface;
using Net_React.Server.Services.Interfaces;

namespace Net_React.Server.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }
        public async Task<CategoryDTO> GetCategoryByName(int id)
        {
            var model = _categoryRepository.GetById(id);
            if (model == null) return null;
            var modelDto = _mapper.Map<CategoryDTO>(model);
            return modelDto;
        }
        public async Task<Category> GetCategoryByName(string name)
        {
            var model = _categoryRepository.GetByName(name);
            if (model == null) return null;
            var modelDto = _mapper.Map<CategoryDTO>(model);
            return modelDto;
        }
        public void AddCategory(Category category) => _categoryRepository.Add(category);
        public void UpdateCategory(Category category) => _categoryRepository.Update(category);
        public void DeleteByCategoryId(int id) => _categoryRepository.Delete(id);
    }
}
