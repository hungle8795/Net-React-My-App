using Net_React.Server.DTOs;
using Net_React.Server.Models;
using Net_React.Server.Repositories.Interface;

namespace Net_React.Server.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync();
        Task<CategoryDTO> GetCategoryByIdAsync(int id);
        Task<IEnumerable<CategoryDTO>> GetCategoryByNameAsync(string name);
        Task AddCategoryAsync(CategoryDTO categoryDto);
        Task UpdateCategoryAsync(CategoryDTO categoryDto);
        Task DeleteCategoryAsync(int id);
    }
}
