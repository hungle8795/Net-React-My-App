using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;
using Net_React.Server.Services.Interfaces;

namespace Net_React.Server.Services.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public IList<Address> GetAllAddresses() => _addressRepository.GetAll();
        public Address GetByAddressId(int id) => _addressRepository.GetById(id);
        public Address GetByUserId(int userId) => _addressRepository.GetByUserId(userId);
        public void AddAddress(Address address) => _addressRepository.Add(address);
        public void UpdateAddress(Address address) => _addressRepository.Update(address);
        public void DeleteByAddressId(int id) => _addressRepository.Delete(id);
    }
}
