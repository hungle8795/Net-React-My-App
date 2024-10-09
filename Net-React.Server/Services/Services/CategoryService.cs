using AutoMapper;
using Net_React.Server.Data;
using Net_React.Server.DTOs;
using Net_React.Server.Models;
using Net_React.Server.Repositories.Interface;
using Net_React.Server.Services.Interfaces;

namespace Net_React.Server.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _unitOfWork.Repository<Category>().GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }
        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var category = await _unitOfWork.Repository<Category>().GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(category);
        }
        public async Task<IEnumerable<CategoryDTO>> GetCategoryByNameAsync(string name)
        {
            var categoryRepository = _unitOfWork.CategoryRepository();
            var categories = await categoryRepository.GetAllByNameAsync(name);
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }
        public async Task AddCategoryAsync(CategoryDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _unitOfWork.Repository<Category>().AddAsync(category);
            await _unitOfWork.CompleteAsync();
        }
        public async Task UpdateCategoryAsync(CategoryDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _unitOfWork.Repository<Category>().UpdateAsync(category);
            await _unitOfWork.CompleteAsync();
        }   
        public async Task DeleteCategoryAsync(int id)
        {
            await _unitOfWork.Repository<Category>().DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
