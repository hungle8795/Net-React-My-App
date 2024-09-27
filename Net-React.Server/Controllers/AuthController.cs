using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Net_React.Server.DTOs;
using Net_React.Server.Services.Interfaces;
using Net_React.Server.Services.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Net_React.Server.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] UserDTO userDto)
        {
            //userDto.Id = Guid.NewGuid();
            userDto.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.PasswordHash);
            await _userService.AddUserAsync(userDto);
            return CreatedAtAction(nameof(_userService.GetByUserNameAsync), new { id = userDto.UserName }, userDto);
        }

        [HttpPost("login")]
        public IActionResult Login(string userName, string password, string role)
        {
            var userDto = new UserDTO()
            {
                UserName = userName,
                PasswordHash = password,
                Role = role
            };
            var user = _userService.GetByUserNameAsync(userDto.UserName).Result.FirstOrDefault();
            if (user == null || !BCrypt.Net.BCrypt.Verify(userDto.PasswordHash, user.PasswordHash))
            {
                return Unauthorized();
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, userDto.UserName),
                new Claim(ClaimTypes.Role, ClaimTypes.Role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TfA7JjzNQ5Rs7SKP"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                    issuer: "ECSiteIssuer",
                    audience: "ECSiteAudience",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);
            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

            //if (!string.IsNullOrEmpty(userDTO.UserName) && !string.IsNullOrEmpty(userDTO.PasswordHash))
            //{
            //    var claims = new[]
            //    {
            //        new Claim(ClaimTypes.Name, userDTO.UserName),
            //        new Claim(ClaimTypes.Role, "User")
            //    };
            //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(""));
            //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //    var token = new JwtSecurityToken(
            //        issuer: "ECSiteIssuer",
            //        audience: "ECSiteAudience",
            //        claims: claims,
            //        expires: DateTime.Now.AddMinutes(30),
            //        signingCredentials: creds);
            //    return Ok(new {token = new JwtSecurityTokenHandler().WriteToken(token)});
            //}
            //return Unauthorized();
        }
    }
}
