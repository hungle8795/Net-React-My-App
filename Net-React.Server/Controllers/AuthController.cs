using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Net_React.Server.DTOs;
using Net_React.Server.Models;
using Net_React.Server.Services.Interfaces;
using Net_React.Server.Services.Services;
using System.Configuration;
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
        private readonly IConfiguration _configuration;
        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] UserDTO userDto)
        {
            //userDto.Id = Guid.NewGuid();
            userDto.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.PasswordHash);
            await _userService.AddUserAsync(userDto);
            return CreatedAtAction(nameof(_userService.GetByUserNameAsync), new { id = userDto.UserName }, userDto);
        }

        //[HttpPost("login")]
        //public IActionResult Login(string userName, string password, string role)
        //{
        //    var userDto = new UserDTO()
        //    {
        //        UserName = userName,
        //        PasswordHash = password,
        //        Role = role
        //    };
        //    var user = _userService.GetByUserNameAsync(userDto.UserName).Result.FirstOrDefault();
        //    if (user == null || !BCrypt.Net.BCrypt.Verify(userDto.PasswordHash, user.PasswordHash))
        //    {
        //        return Unauthorized();
        //    }
        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.Name, userDto.UserName),
        //        new Claim(ClaimTypes.Role, ClaimTypes.Role)
        //    };
        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TfA7JjzNQ5Rs7SKP"));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //    var token = new JwtSecurityToken(
        //            issuer: _configuration["Jwt:Issuer"],
        //            audience: _configuration["Jwt:Audience"],
        //            claims: claims,
        //            expires: DateTime.Now.AddMinutes(30),
        //            signingCredentials: creds);
        //    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        //}

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDTO userDto)
        {
            var user = Authenticate(userDto);
            if(user != null) {
                var token = GenerateToken(user);
                return Ok(new {token });
            }
            return Unauthorized();
        }

        private User Authenticate(UserDTO userDto)
        {
            // Kiểm tra thông tin đăng nhập với database
            // Nếu thành công, trả về thông tin người dùng
            if(userDto.UserName == "exam" && userDto.PasswordHash == "expass")
            {
                return new User { 
                    UserName = userDto.UserName,
                    Email = "example@gmail.com"
                };
            }
            return null;
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TfA7JjzNQ5Rs7SKP"));
            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
