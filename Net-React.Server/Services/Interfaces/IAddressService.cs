using Net_React.Server.DTOs;
using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;

namespace Net_React.Server.Services.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressDTO>> GetAllAddressesAsync();
        Task<AddressDTO> GetAddressByIdAsync(int id);
        Task<IEnumerable<AddressDTO>> GetAllAddressByUserIdAsync(int userId);
        Task AddAddressAsync(AddressDTO addressDto);
        Task UpdateAddressAsync(AddressDTO addressDto);
        Task DeleteAddressAsync(int id);
    }
}
