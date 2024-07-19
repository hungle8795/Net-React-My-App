using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;
using Net_React.Server.Repositories.Repository;

namespace Net_React.Server.Repositories.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        Category GetByName(string name);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}
