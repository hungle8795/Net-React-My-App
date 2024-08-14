using Net_React.Server.Models;
using System.Linq.Expressions;

namespace Net_React.Server.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> GetByNameAsync(string name);
        Task<IEnumerable<Product>> FindAsync(Expression<Func<Product, bool>> predicate);
        Task AddAsync(Product entity);
        Task AddRangeAsync(IEnumerable<Product> entities);
        Task Remove(Product entity);
        Task RemoveRange(IEnumerable<Product> entities);
    }
}
