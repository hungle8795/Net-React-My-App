using Net_React.Server.DTOs.Auth;
using Net_React.Server.DTOs.User;
using Net_React.Server.DTOs.User;
using Net_React.Server.Models;

namespace Net_React.Server.Services.Interfaces
{
    public interface IAccountsService
    {
        //Task<ServiceResponse<List<GetUserDTO>>> GetAllUsers();
        //Task<ServiceResponse<GetUserDTO>> GetUserById(int id);
        Task<ServiceResponse<List<AddAccountDTO>>> Register(AddAccountDTO newUser);
        Task<ServiceResponse<AccountRespDTO>> Login(AccountReqDTO request);
        //Task<ServiceResponse<GetUserDTO>> UpdateUser(UpdateUserDTO updatedProduct);
        //Task<ServiceResponse<List<GetUserDTO>>> DeleteUser(int id);
    }
}
