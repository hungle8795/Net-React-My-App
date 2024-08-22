using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net_React.Server.DTOs.Accounts;
using Net_React.Server.DTOs.Auth;
using Net_React.Server.DTOs.User;
using Net_React.Server.Models;
using Net_React.Server.Services.Interfaces;
using Net_React.Server.Services.Services;

namespace Net_React.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService _userService;
        public AccountsController(IAccountsService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<List<AddAccountDTO>>>> Register(AddAccountDTO newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _userService.Register(newUser));
        }

        [HttpPost("login"), AllowAnonymous]
        public async Task<ActionResult<ServiceResponse<AccountRespDTO>>> Login(AccountReqDTO request)
        {
            return Ok(await _userService.Login(request));
        }

    }
}
