using Net_React.Server.Models;
using System.Linq.Expressions;

namespace Net_React.Server.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllByNameAsync(string name); 
        Task<IEnumerable<Product>> GetAllByCategoryIdAsync(int categoryId);
        Task AddAsync(Product entity);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
