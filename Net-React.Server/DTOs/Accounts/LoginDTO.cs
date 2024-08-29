﻿using System.ComponentModel.DataAnnotations;

namespace Net_React.Server.DTOs.Auth
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
