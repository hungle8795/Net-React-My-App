using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Net_React.Server.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Net_React.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenGenerateController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TokenGenerateController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        [HttpPost]
        public IActionResult Post(Accounts loginRequest)
        {
            //    if (loginRequest.Email != "Admin" && loginRequest.Password != "Passw0rd")
            //    {
            //        var issuer = _configuration["Jwt:Issuer"];
            //        var audience = _configuration["Jwt:Audience"];
            //        var _key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            //        var tokenDescriptor = new SecurityTokenDescriptor
            //        {
            //            Subject = new ClaimsIdentity(new[]
            //                            {
            //                new Claim("Id",Guid.NewGuid().ToString()),
            //                new Claim(JwtRegisteredClaimNames.Sub, loginRequest.Username),
            //                new Claim(JwtRegisteredClaimNames.Email, loginRequest.Username),
            //                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            //           }),

            //            Expires = DateTime.UtcNow.AddMinutes(10),
            //            Issuer = issuer,
            //            Audience = audience,
            //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature)
            //        };



            //        var tokenHandler = new JwtSecurityTokenHandler();
            //        var token = tokenHandler.CreateToken(tokenDescriptor);
            //        var jwttoken = tokenHandler.WriteToken(token);
            //        var stringToken = tokenHandler.WriteToken(token);
            //        return Ok(stringToken);
            //    }
            return Ok("Unauthorized");
        }
    }
}
