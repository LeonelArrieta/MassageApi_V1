using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MassageApi_V1.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Nombre")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [DisplayName("Nombre")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; } = "";

        [Required]
        [DisplayName("Correo Electrónico")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage ="El correo electrónico es inválido.")]
        public string Address { get; set; }
        [DisplayName("Número de teléfono")]
        public int PhoneNumber { get; set; } = 0;
        [DisplayName("Fecha de nacimiento")]
        public DateTime Birthdate { get; set; } = DateTime.Now!;
        [DisplayName("DNI")]
        public int DNI { get; set; }
        [DisplayName("Observaciones")]
        [StringLength(300)]
        public string Observations { get; set; } = "";
    }
}
