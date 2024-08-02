using Net_React.Server.DTOs;
using Net_React.Server.Models;
using Net_React.Server.Repositories.Interface;

namespace Net_React.Server.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategories();
        Task<CategoryDTO> GetCategoryById(int id);
        Task<CategoryDTO> GetCategoryByName(string name); 
        void AddCategory(CategoryDTO category);
        void UpdateCategory(CategoryDTO category);
        void DeleteByCategoryId(int id);
    }
}
