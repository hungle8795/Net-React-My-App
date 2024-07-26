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

        [HttpPost]
        public async Task<ActionResult<string>> Add(Address address)
        {
            _addressService.AddAddress(address);
            //return CreatedAtAction("GetAddress", new { id = address.Id }, address);
            var mess = new MessageReport()
            {
                IsSuccess = true,
                Message = "New Record is added."
            };
            return mess.Message;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Update(int id, Address address)
        {
            //if(id != address.Id) return BadRequest();
            //var model = _addressService.GetByAddressId(id);
            //if (model == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    _addressService.UpdateAddress(address);
            //    return Ok(address);
            //}
            var model = _addressService.GetByAddressId(id);
            if (model == null)
            {
                var mess = new MessageReport()
                {
                    IsSuccess = false,
                    Message = "Model is not exist."
                };
                return mess.Message;
            }
            else
            {
                _addressService.UpdateAddress(address);
                var mess = new MessageReport()
                {
                    IsSuccess = true,
                    Message = "Model is updated."
                };
                return mess.Message;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteById(int id)
        {
            //var model = _addressService.GetByAddressId(id);
            //if (model == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    _addressService.DeleteByAddressId(id);
            //    return Ok("Deleted " + id);
            //}
            var model = _addressService.GetByAddressId(id);
            if (model == null)
            {
                var mess = new MessageReport()
                {
                    IsSuccess = false,
                    Message = "Model is not exist."
                };
                return mess.Message;
            }
            else
            {
                _addressService.DeleteByAddressId(id);
                var mess = new MessageReport()
                {
                    IsSuccess = true,
                    Message = "Model is deleted."
                };
                return mess.Message;
            }
        }
    }
}
