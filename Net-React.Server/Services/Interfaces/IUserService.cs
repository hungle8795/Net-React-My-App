using Net_React.Server.DTOs;

namespace Net_React.Server.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDTO>> GetByUserNameAsync(string userName);
        Task AddUserAsync(UserDTO userDTO);
        Task UpdateUserAsync(UserDTO userDTO);
        Task DeleteUserAsync(int id);
    }
}
