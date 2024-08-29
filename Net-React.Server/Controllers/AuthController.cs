﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net_React.Server.DTOs.Auth;
using Net_React.Server.DTOs.User;
using Net_React.Server.Services.Interfaces;

namespace Net_React.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _accountService;
        public AuthController(IAuthService accountService)
        {
            _accountService = accountService;
        }

        #region Register
        [HttpPost()]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var registerResult = await _accountService.RegisterAsync(registerDto);
            return StatusCode(registerResult.StatusCode, registerResult.Message);
        }
        #endregion

        #region Login
        [HttpPost(), AllowAnonymous]
        [Route("login")]
        public async Task<ActionResult<LoginServiceResponseDTO>> Login([FromBody] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loginResult = await _accountService.LoginAsync(loginDTO);
            if (loginResult is null)
            {
                return Unauthorized("Your credentials are invalid. Please contact to an Admin");
            }

            return Ok(loginResult);
        }
        #endregion

        #region Me
        [HttpPost]
        [Route("me")]
        public async Task<ActionResult<LoginServiceResponseDTO>> Me([FromBody] MeDTO token)
        {
            try
            {
                var me = await _accountService.MeAsync(token);
                if(me is not null)
                {
                    return Ok(me);
                }
                else
                {
                    return Unauthorized("Invalid Token");
                }
            }
            catch (Exception)
            {
                return Unauthorized("Invalid Token");
            }
        }
        #endregion
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
