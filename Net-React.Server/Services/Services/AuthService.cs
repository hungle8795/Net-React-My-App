using AutoMapper;
using backend.Data;
using backend_dotnet7.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Net_React.Server.Constants;
using Net_React.Server.DTOs.Auth;
using Net_React.Server.DTOs.General;
using Net_React.Server.DTOs.User;
using Net_React.Server.Interfaces;
using Net_React.Server.Models;
using Net_React.Server.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Net_React.Server.Services.Services
{
    public class AuthService : IAuthService
    {
        #region Constructor & DI
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private AuthOptions authOptions;
        #endregion

        public AuthService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogService logService,
            IMapper mapper, 
            DataContext context, 
            IConfiguration configuration,
            IOptions<AuthOptions> authOptions)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logService = logService;
            _mapper = mapper;
            _context = context;
            _configuration = configuration;
            this.authOptions = authOptions.Value;
        }

        #region SeedRolesAsync
        public async Task<GeneralServiceResponseDto> SeedRolesAsync()
        {
            bool isOwnerRoleExists = await _roleManager.RoleExistsAsync(StaticUserRoles.OWNER);
            bool isAdminRoleExists = await _roleManager.RoleExistsAsync(StaticUserRoles.ADMIN);
            bool isManagerRoleExists = await _roleManager.RoleExistsAsync(StaticUserRoles.MANAGER);
            bool isUserRoleExists = await _roleManager.RoleExistsAsync(StaticUserRoles.USER);

            if (isOwnerRoleExists && isAdminRoleExists && isManagerRoleExists && isUserRoleExists)
                return new GeneralServiceResponseDto()
                {
                    IsSucceed = true,
                    StatusCode = 200,
                    Message = "Roles Seeding is Already Done"
                };

            await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.OWNER));
            await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.ADMIN));
            await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.MANAGER));
            await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.USER));

            return new GeneralServiceResponseDto()
            {
                IsSucceed = true,
                StatusCode = 201,
                Message = "Roles Seeding Done Successfully"
            };
        }
        #endregion

        #region Register
        /// <summary>
        /// Feat: Register Account
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public async Task<GeneralServiceResponseDto> RegisterAsync(RegisterDto registerDto)
        {
            var response = new GeneralServiceResponseDto();
            try
            {
                var isExistsUser = await _userManager.FindByNameAsync(registerDto.UserName);
                if (isExistsUser is not null)
                    return new GeneralServiceResponseDto()
                    {
                        IsSucceed = false,
                        StatusCode = 409,
                        Message = "UserName Already Exists"
                    };

                ApplicationUser newUser = new ApplicationUser()
                {
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    Email = registerDto.Email,
                    UserName = registerDto.UserName,
                    Address = registerDto.Address,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var createUserResult = await _userManager.CreateAsync(newUser, registerDto.Password);

                if(!createUserResult.Succeeded)
                {
                    var errorString = "User Creation failed because: ";
                    foreach (var error in createUserResult.Errors)
                    {
                        errorString += " # " + error.Description;
                    }
                    return new GeneralServiceResponseDto()
                    {
                        IsSucceed = false,
                        StatusCode = 400,
                        Message = errorString
                    };
                }

                // Add a Default USER Role to all users
                await _userManager.AddToRoleAsync(newUser, StaticUserRoles.USER);
                await _logService.SaveNewLog(newUser.UserName, "Registered to Website");
            } 
            catch (Exception ex)
            {
                response.IsSucceed = false;
                response.Message = ex.Message;
            }

            return new GeneralServiceResponseDto()
            {
                IsSucceed = true,
                StatusCode = 201,
                Message = "User Created Successfully"
            };
            
            // // var isExistsUser = await _userManager.FindByNameAsync(registerDto.UserName);
            // // var response = new ServiceResponse<List<RegisterDto>>();

            // try
            // {
            //     var user = _mapper.Map<Auth>(newUser);

            //     string passwordHash = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

            //     user.Email = newUser.Email;
            //     user.Password = passwordHash;

            //     // Check email is already in use
            //     if (_context.Auth.Any(u => u.Email == user.Email))
            //     {
            //         response.Message = "Email is already in use.";
            //         response.IsSuccess = false;
            //         response.StatusCode = 409;
            //     }
            //     else
            //     {
            //         _context.Auth.Add(user);
            //         await _context.SaveChangesAsync();

            //         response.Data = await _context.Users
            //                .Select(p => _mapper.Map<AddAccountDTO>(p))
            //                .ToListAsync();
            //         response.IsSuccess = true;
            //         response.StatusCode = 201;
            //         response.Message = "Account created successfully!";
            //     }
            // }
            // catch (Exception ex)
            // {
            //     response.IsSuccess = false;
            //     response.Message = ex.Message;
            // }
            
            // return response;
        }
        #endregion
        #region Login
        /// <summary>
        /// Feat: User login account that registered
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<LoginServiceResponseDTO?> LoginAsync(LoginDto loginDto)
        {
            // Find user with username
            var user = await _userManager.FindByNameAsync(loginDto.UserName);
            if (user is null)
                return null;

            // check password of user
            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if(!isPasswordCorrect)
                return null;

            // Return Token and userInfo to front-end
            var newToken = await GenerateJWTTokenAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var userInfo = GenerateUserInfoObject(user,roles);
            await _logService.SaveNewLog(user.UserName, "New Login");

            return new LoginServiceResponseDTO()
            {
                NewToken = newToken,
                UserInfo = userInfo
            };

            // var serviceResponse = new ServiceResponse<AccountRespDTO>();
            // try
            // {
            //     var dbUser = await _context.Auth.FirstOrDefaultAsync(u => u.Email == request.Email);
            //     if (dbUser == null)
            //     {
            //         serviceResponse.IsSuccess = false;
            //         serviceResponse.Message = "Email not found.";
            //         return serviceResponse;
            //     }

            //     if (!BCrypt.Net.BCrypt.Verify(request.Password, dbUser.Password))
            //     {
            //         serviceResponse.IsSuccess = false;
            //         serviceResponse.Message = "Wrong password.";
            //         return serviceResponse;
            //     }

            //     var token = GenerateJwtToken(dbUser);

            //     //var authResponse = new AccountRespDTO
            //     //{
            //     //    Token = token,
            //     //    UserId = dbUser.Id,
            //     //    FirstName = dbUser.FirstName,
            //     //    LastName = dbUser.LastName,
            //     //    Email = dbUser.Email,
            //     //};

            //     return new ServiceResponse<AccountRespDTO>()
            //     {
            //         IsSuccess = true,
            //         StatusCode = 201,
            //         Token = token,
            //         Message = "Login successfully!"
            //     };
            //     //serviceResponse.Data = authResponse;
            // }
            // catch (Exception ex)
            // {
            //     serviceResponse.IsSuccess = false;
            //     serviceResponse.Message = ex.Message;
            // }

            // return serviceResponse;
        }

        #endregion

        #region GenerateJWTTokenAsync
        private async Task<string> GenerateJWTTokenAsync(ApplicationUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var signingCredentials = new SigningCredentials(authSecret, SecurityAlgorithms.HmacSha256);

            var tokenObject = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: signingCredentials
                );

            string token = new JwtSecurityTokenHandler().WriteToken(tokenObject);
            return token;
        }
        #endregion
        
        #region GenerateUserInfoObject
        private UserInfoResult GenerateUserInfoObject(ApplicationUser user, IEnumerable<string> Roles)
        {
            // Instead of this, You can use Automapper packages. But i don't want it in this project
            return new UserInfoResult()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                Roles = Roles
            };
        }
        #endregion

        #region GenerateJWTTokenAsync
        /// <summary>
        /// GenerateJwtToken
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string GenerateJwtToken(Auth acc)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, acc.Id.ToString()),
                //new Claim(ClaimTypes.Email, acc.Email),
                //new Claim(ClaimTypes.Role, acc.Role)
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "Customer")

                //new Claim(ClaimTypes.Role, "Customer")
            };

            var jwtToken = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.Now.AddHours(3),

                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                       Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
                        ),
                    SecurityAlgorithms.HmacSha256Signature)
                );
            return string.Concat("Bearer ", new JwtSecurityTokenHandler().WriteToken(jwtToken));
        }
        #endregion
    }
}
