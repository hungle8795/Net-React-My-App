using Net_React.Server.Models;

namespace Net_React.Server.Services.Interfaces
{
    public interface IAuthService
    {
        string Login(Login login);
        //Task<Response<IdentityResult>> RegisterSystemUser(SystemRegisterUserDTO user);
        //Task<Response<LoginResponseDTO>> LoginSystemUser(SystemSignInUserDTO credentials);
    }
}
