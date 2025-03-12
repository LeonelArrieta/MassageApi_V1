using System.ComponentModel.DataAnnotations;

namespace MassageApi_V1.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        [EmailAddress]
        public string Address { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public int DNI { get; set; }
        public string Observations { get; set; } = null!;
    }
}
