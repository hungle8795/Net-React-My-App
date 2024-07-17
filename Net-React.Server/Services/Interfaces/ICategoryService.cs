using Net_React.Server.Models;
using Net_React.Server.Repositories.Interface;

namespace Net_React.Server.Services.Interfaces
{
    public interface ICategoryService : ICategoryRepository
    {
        Category GetByName(string name);
    }
}
