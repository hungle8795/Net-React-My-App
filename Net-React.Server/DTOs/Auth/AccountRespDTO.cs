using Net_React.Server.Models;

namespace Net_React.Server.DTOs.Auth
{
    public class AccountRespDTO : BaseModel
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Initials { get; set; }
    }
}
