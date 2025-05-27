using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MassageApi_V1.Models
{
    public class User
    {
        [Required]
        [EmailAddress]
        [Key]
        [DisplayName("Correo Electrónico")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "El correo electrónico es inválido.")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Contraseña")]
        [PasswordPropertyText(true)]
        public string Password { get; set; }
        public string Role { get; set; } = "CommonUser";
    }
}
