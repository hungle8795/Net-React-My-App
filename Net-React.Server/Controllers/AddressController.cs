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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Address>> GetById(int id)
        {
            return _addressService.GetByAddressId(id);
        }

        [HttpGet("{userid}")]
        public async Task<ActionResult<Address>> GetByUserId(int userId)
        {
            return _addressService.GetByUserId(userId);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Address>> Add(Address address)
        {
            _addressService.AddAddress(address);
            return CreatedAtAction("GetAddress", new { id = address.Id }, address);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, Address address)
        {
            if (id != address.Id) return BadRequest();
            var model = _addressService.GetByAddressId(id);
            if (model == null)
            {
                return NotFound();
            }
            else
            {
                model.PhoneNumber = address.PhoneNumber;
                model.RoomNumber = address.RoomNumber;
                model.LastName = address.LastName;
                model.FirstName = address.FirstName;
                model.User = address.User;
                model.ChromeStreetaddress = address.ChromeStreetaddress;
                model.City = address.City;
                model.Province = address.Province;
                model.Region = address.Region;
                model.UserId = address.UserId;
                model.ZipCode = address.ZipCode;
                _addressService.UpdateAddress(model);
                return Ok(address);
            }
        }

        [HttpDelete("Delete/{id}")]
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
