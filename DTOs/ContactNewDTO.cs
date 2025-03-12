using MassageApi_V1.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MassageApi_V1.DTOs
{
    public class ContactNewDTO
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        [EmailAddress]
        public string Address { get; set; } = null!;
        public int PhoneNumber { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Birthdate { get; set; }
        public int DNI { get; set; }
        public string Observations { get; set; } = null!;

    }
}
