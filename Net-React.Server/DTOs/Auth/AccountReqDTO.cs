using System.ComponentModel.DataAnnotations;

namespace Net_React.Server.DTOs.Auth
{
    public class AccountReqDTO
    {
        [Required(ErrorMessage = "Email is required")]
        public required string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required")]
        public required string Password { get; set; } = string.Empty;
    }
}
