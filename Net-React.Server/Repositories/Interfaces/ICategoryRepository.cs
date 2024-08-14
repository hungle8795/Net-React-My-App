using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;
using Net_React.Server.Repositories.Repository;
using System.Linq.Expressions;

namespace Net_React.Server.Repositories.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> GetByNameAsync(string name);
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
    }
}
