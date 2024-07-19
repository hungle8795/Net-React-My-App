using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;
using Net_React.Server.Repositories.Repository;

namespace Net_React.Server.Repositories.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(ECommerceSampContext context) : base(context)
        {
        }
        public Address GetByUserId(int userId)
        {
            return _context.Addresses.FirstOrDefault(n => n.UserId == userId);
        }
    }
}