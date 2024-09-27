using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Net_React.Server.Repositories.Repository;

namespace Net_React.Server.Repositories.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(ECommerceSampContext context) : base(context)
        {
        }
        public async Task<IEnumerable<User>> GetByUserNameAsync(string userName)
        {
            return await _context.Users.Where(n => n.UserName ==  userName).ToListAsync();
        }
    }
}
