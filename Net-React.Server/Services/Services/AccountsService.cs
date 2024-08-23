using AutoMapper;
using Azure;
using Azure.Core;
using backend.Data;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Net_React.Server.DTOs.Auth;
using Net_React.Server.DTOs.User;
using Net_React.Server.Models;
using Net_React.Server.Services.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Net_React.Server.Services.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private AuthOptions authOptions;

        public AccountsService(IMapper mapper, 
            DataContext context, 
            IConfiguration configuration,
            IOptions<AuthOptions> authOptions)
        {
            _mapper = mapper;
            _context = context;
            _configuration = configuration;
            this.authOptions = authOptions.Value;
        }

        /// <summary>
        /// Feat: Register Account
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<List<AddAccountDTO>>> Register(AddAccountDTO newUser)
        {
            var response = new ServiceResponse<List<AddAccountDTO>>();

            try
            {
                var user = _mapper.Map<Accounts>(newUser);

                string passwordHash = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

                user.Email = newUser.Email;
                user.Password = passwordHash;

                // Check email is already in use
                if (_context.Accounts.Any(u => u.Email == user.Email))
                {
                    response.Message = "Email is already in use.";
                    response.IsSuccess = false;
                }
                else
                {
                    _context.Accounts.Add(user);
                    await _context.SaveChangesAsync();

                    response.Data = await _context.Users
                           .Select(p => _mapper.Map<AddAccountDTO>(p))
                           .ToListAsync();
                    response.Message = "Account created successfully!";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            
            return response;
        }

        /// <summary>
        /// Feat: Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<AccountRespDTO>> Login(AccountReqDTO request)
        {
            var serviceResponse = new ServiceResponse<AccountRespDTO>();
            try
            {
                var dbUser = await _context.Accounts.FirstOrDefaultAsync(u => u.Email == request.Email);
                if (dbUser == null)
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Email not found.";
                    return serviceResponse;
                }

                if (!BCrypt.Net.BCrypt.Verify(request.Password, dbUser.Password))
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Wrong password.";
                    return serviceResponse;
                }

                var token = GenerateJwtToken(dbUser);

                var authResponse = new AccountRespDTO
                {
                    Token = token,
                    UserId = dbUser.Id,
                    FirstName = dbUser.FirstName,
                    LastName = dbUser.LastName,
                    Email = dbUser.Email,

                };
                serviceResponse.Message = "Login successfully!";
                serviceResponse.Data = authResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
        /// <summary>
        /// GenerateJwtToken
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string GenerateJwtToken(Accounts acc)
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
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(30),
                //expires: DateTime.UtcNow.AddDays(authOptions.AccessLifetime),

                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                       Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
                        ),
                    SecurityAlgorithms.HmacSha256Signature)
                );
            return string.Concat("Bearer ", new JwtSecurityTokenHandler().WriteToken(jwtToken));
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
