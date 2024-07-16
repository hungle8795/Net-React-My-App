using Net_React.Server.Models;
using Net_React.Server.Repositories.Repository;

namespace Net_React.Server.Repositories.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetByName(string name);
    }
}
