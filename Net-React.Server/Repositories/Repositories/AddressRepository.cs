using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;
using Net_React.Server.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace Net_React.Server.Repositories.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(ECommerceSampContext context) : base(context)
        {
        }
        public async Task<Address> GetByUserIdAsync(int userId)
        {
            return await _context.Set<Address>()
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }
    }
}