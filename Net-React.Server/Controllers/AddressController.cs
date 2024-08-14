using Microsoft.AspNetCore.Mvc;
using Net_React.Server.DTOs;
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
        public async Task<IActionResult> GetAll()
        {
            var addressesDto = await _addressService.GetAllAddressesAsync();
            return Ok(addressesDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var addressDto = await _addressService.GetAddressByIdAsync(id);
            return addressDto == null ? NotFound() : Ok(addressDto);
        }

        [HttpGet("{userid}")]
        public async Task<ActionResult<Address>> GetByUserId(int userId)
        {
            var addressDto = await _addressService.GetAddressByUserIdAsync(userId);
            return addressDto != null ? Ok(addressDto) : NotFound();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Add([FromBody] AddressDTO AddressDto)
        {
            await _addressService.AddAddressAsync(AddressDto);
            return CreatedAtAction(nameof(GetById), new { id = AddressDto.Id }, AddressDto);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] AddressDTO addressDto)
        {
            await _addressService.UpdateAddressAsync(addressDto);
            return Ok(addressDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _addressService.GetAddressByIdAsync(id);
            return NoContent();
        }
    }
}
