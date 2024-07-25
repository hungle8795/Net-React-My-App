using Microsoft.AspNetCore.Mvc;
using Net_React.Server.Models;
using Net_React.Server.Services.Interfaces;
using Net_React.Server.Services.Services;

namespace Net_React.Server.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        [HttpGet]
        public async Task<IList<Address>> GetAll()
        {
            return _addressService.GetAllAddresses();
        }

        [HttpGet("{id}")]
        public async Task<Address> GetById(int id)
        {
            return _addressService.GetByAddressId(id);
        }

        [HttpGet("{userid}")]
        public async Task<Address> GetByUserId(int userId)
        {
            return _addressService.GetByUserId(userId);
        }
        [HttpPost]

        public async Task<ActionResult<Address>> Add(Address address)
        {
            _addressService.AddAddress(address);
            return CreatedAtAction("GetAddress", new { id = address.Id }, address);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Address address)
        {
            if(id != address.Id) return BadRequest();
            var model = _addressService.GetByAddressId(id);
            if (model == null)
            {
                return NotFound();
            }
            else
            {
                _addressService.UpdateAddress(address);
                return Ok(address);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var model = _addressService.GetByAddressId(id);
            if (model == null)
            {
                return NotFound();
            }
            else
            {
                _addressService.DeleteByAddressId(id);
                return Ok("Deleted " + id);
            }
        }
    }
}
