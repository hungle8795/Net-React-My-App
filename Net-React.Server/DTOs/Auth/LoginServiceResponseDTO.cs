namespace Net_React.Server.DTOs.Auth;

public class LoginServiceResponseDTO
{
    public string NewToken { get; set; }
    
    // This would be returned to front-end
    public UserInfoResult UserInfo { get; set; }
}
