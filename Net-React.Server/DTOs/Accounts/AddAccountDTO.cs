using Net_React.Server.Models;
using System.ComponentModel.DataAnnotations;

namespace Net_React.Server.DTOs.User
{
    public class AddAccountDTO
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email address is invalid")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100,ErrorMessage = "The {0} must be at least {2} characters long", MinimumLength = 8)]
        [Display(Name = "Password")]
        public string? Password { get; set; }
    }
}
