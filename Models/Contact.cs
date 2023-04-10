using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace MassageApi_V1.Models
{
    public class Contact
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
        public DataSheet DataSheet { get; set; }=null!;
        public Shift Shift { get; set; }=null!;

    }
}
