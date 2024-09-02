using Net_React.Server.DTOs.Auth;
using Net_React.Server.DTOs.General;
using Net_React.Server.DTOs.User;

namespace Net_React.Server.Services.Interfaces
{
    public interface IAuthService
    {
        //Task<ServiceResponse<List<GetUserDTO>>> GetAllUsers();
        //Task<ServiceResponse<GetUserDTO>> GetUserById(int id);
        Task<GeneralServiceResponseDto> SeedRolesAsync();
        Task<GeneralServiceResponseDto> RegisterAsync(RegisterDto newUser);
        Task<LoginServiceResponseDTO?> LoginAsync(LoginDTO request);
        Task<LoginServiceResponseDTO?> MeAsync(MeDTO meDto);
        Task<IEnumerable<string>> GetUsernamesListAsync();
        //Task<ServiceResponse<GetUserDTO>> UpdateUser(UpdateUserDTO updatedProduct);
        //Task<ServiceResponse<List<GetUserDTO>>> DeleteUser(int id);
    }
}
