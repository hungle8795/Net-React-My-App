using Net_React.Server.DTOs;
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
        Task<IEnumerable<Category>> FindAsync(Expression<Func<Category, bool>> predicate);
        Category GetById(int id);
        Category GetByName(string name);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);

        Task AddAsync(Category entity);
        Task AddRangeAsync(IEnumerable<Category> entities);
        //void Update(Category entity);
        void Remove(Category entity);
        void RemoveRange(IEnumerable<Category> entities);
    }
}
