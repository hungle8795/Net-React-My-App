using Net_React.Server.Models;
using Net_React.Server.Repositories.Interface;

namespace Net_React.Server.Services.Interfaces
{
    public interface ICategoryService
    {
        IList<Category> GetAllCategories();
        Category GetByCategoryId(int id);
        Category GetByCategoryName(string name); 
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteByCategoryId(int id);
    }
}
