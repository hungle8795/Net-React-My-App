using Net_React.Server.Models;

namespace Net_React.Server.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        Product GetByName(string name);
        void Add(Product category);
        void Update(Product category);
        void Delete(int id);
    }
}
