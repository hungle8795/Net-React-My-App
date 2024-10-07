using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;
using Net_React.Server.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace Net_React.Server.Repositories.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(EcommerceSampContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Address>> GetAllByUserIdAsync(int userId)
        {
            return await _context.Addresses.Where(n => n.UserId == userId).ToListAsync();
        }
    }
}