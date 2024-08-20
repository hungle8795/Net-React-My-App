using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Net_React.Server.Models;
using Net_React.Server.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Net_React.Server.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly ILogger _logger;
        private List<Login> _auth = new List<Login> 
        {
            new Login { Username = "Admin", Password = "Password" }
        };

        public string Login() 
        {
            throw new NotImplementedException();
        }

        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Login(Login login)
        {
            var LoginUser = _auth.SingleOrDefault(x => x.Username == login.Username && x.Password == login.Password);

            if (LoginUser == null)
            {
                return string.Empty;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, login.Username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string userToken = tokenHandler.WriteToken(token);
            return userToken;
        }

        //private readonly SignInManager<SystemUser> _signInManager;
        //private readonly UserManager<SystemUser> _userManager;

        //public AuthService(SignInManager<SystemUser> signInManager,
        //    UserManager<SystemUser> userManager)
        //{
        //    _signInManager = signInManager;
        //    _userManager = userManager;
        //}
        //public async Task<Response<LoginResponseDTO>> LoginSystemUser(SystemSignInUserDTO credentials)
        //{
        //    var user = await _userManager.FindByEmailAsync(credentials.Email);
        //    if (user == null)
        //    {
        //        return new()
        //        {
        //            Success = false,
        //            Data = new LoginResponseDTO() { },
        //            Message = "Email or password is incorrect",
        //        };
        //    }
        //    var result = await _signInManager.PasswordSignInAsync(user.UserName, credentials.Password, false, true);
        //    if (!result.Succeeded)
        //    {
        //        return new()
        //        {
        //            Success = false,
        //            Data = new LoginResponseDTO() { },
        //            Message = "Email or password is incorrect",
        //        };
        //    }
        //    return new Response<LoginResponseDTO>()
        //    {
        //        Message = "Login Successfull!",
        //        Data = new()
        //        {
        //            Id = user.Id,
        //            Username = user.UserName,
        //            Name = user.Name,
        //            Email = user.Email,
        //            Phone = user.Phone,
        //            Address = user.Address,
        //        },
        //    };
        //}

        //public async Task<Response<IdentityResult>> RegisterSystemUser(SystemRegisterUserDTO user)
        //{
        //    SystemUser _user = new()
        //    {
        //        UserName = user.Username,
        //        Email = user.Email,
        //        Name = user.Name,
        //    };
        //    var result = await _userManager.CreateAsync(_user, user.Password);
        //    return new Response<IdentityResult>()
        //    {
        //        Success = true,
        //        Data = result,
        //        Message = result.Succeeded ? "User Registration Successfull!" : "User Registration Failed!"
        //    };
        //}
    }
}
