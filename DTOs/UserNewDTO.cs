﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MassageApi_V1.DTOs
{
    public class UserNewDTO
    {
        [Required]
        [EmailAddress]        
        public string Email { get; set; } = string.Empty;
        [Required]
        [PasswordPropertyText(true)]
        public string Password { get; set; } = string.Empty;
    }
}
