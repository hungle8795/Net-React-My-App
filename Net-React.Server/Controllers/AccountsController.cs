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
        private readonly IAccountsService _accountService;
        public AccountsController(IAccountsService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<List<AddAccountDTO>>>> Register(AddAccountDTO newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _accountService.Register(newUser));
        }

        [HttpPost("login"), AllowAnonymous]
        public async Task<ActionResult<ServiceResponse<AccountRespDTO>>> Login(AccountReqDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _accountService.Login(request));
        }

        //[Authorize]
        //[HttpPost("SignOut")]
        //public IActionResult SignOut()
        //{
        //    string id = User.Claims.FirstOrDefault(x => x.Type == "id")?.Value;
        //    if (String.IsNullOrEmpty(id)) return NotFound();
        //    _accountService.SignOut(Int32.Parse(id));
        //    return Ok();
        //}
    }
}
