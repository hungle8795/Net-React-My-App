using Net_React.Server.Models;

namespace Net_React.Server.Repositories.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetByUserNameAsync(string name);
        Task AddAsync(User User);
        Task UpdateAsync(User User);
        Task DeleteAsync(int id);
    }
}
