using Microsoft.AspNetCore.Mvc;
using Net_React.Server.Models;
using Net_React.Server.Services.Interfaces;
using Net_React.Server.Services.Services;

namespace Net_React.Server.Controllers
{
    public class AddressController
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        public async Task<IEnumerable<Address>> GetAll()
        {
            return _addressService.GetAllAddresses();
        }

        [HttpGet]
        public async Task<Address> GetById(int id)
        {
            return _addressService.GetByAddressId(id);
        }

        [HttpGet("userid")]
        public async Task<Address> GetByUserId(int userId)
        {
            return _addressService.GetByUserId(userId);
        }
        public async void Add(Address address)
        {
            _addressService.AddAddress(address);
        }
        public async void Update(Address address)
        {
            _addressService.AddAddress(address);
        }
        public async void DeleteById(int id)
        {
            _addressService.DeleteByAddressId(id);
        }
    }
}
