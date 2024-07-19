using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;

namespace Net_React.Server.Services.Interfaces
{
    public interface IAddressService
    {
        IEnumerable<Address> GetAllAddresses();
        Address GetByAddressId(int id);
        Address GetByUserId(int userId);
        void AddAddress(Address address);
        void UpdateAddress(Address address);
        void DeleteByAddressId(int id);
    }
}
