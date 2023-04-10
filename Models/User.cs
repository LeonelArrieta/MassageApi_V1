using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MassageApi_V1.Models
{
    public class User
    {
        [Required]
        [EmailAddress]
        [Key]
        public string Email { get; set; } = null!;
        [Required]
        [PasswordPropertyText(true)]
        public string Password { get; set; } = null!;
        public string Role { get; set; }="CommonUser";
    }
}
