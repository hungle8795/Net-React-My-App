using Net_React.Server.DTOs.Auth;
using Net_React.Server.DTOs.General;
using Net_React.Server.DTOs.User;
using Net_React.Server.Models;

namespace Net_React.Server.Services.Interfaces
{
    public interface IAuthService
    {
        //Task<ServiceResponse<List<GetUserDTO>>> GetAllUsers();
        //Task<ServiceResponse<GetUserDTO>> GetUserById(int id);
        Task<GeneralServiceResponseDto> RegisterAsync(RegisterDto newUser);
        Task<LoginServiceResponseDTO?> LoginAsync(LoginDto request);
        //Task<ServiceResponse<GetUserDTO>> UpdateUser(UpdateUserDTO updatedProduct);
        //Task<ServiceResponse<List<GetUserDTO>>> DeleteUser(int id);
    }
}
