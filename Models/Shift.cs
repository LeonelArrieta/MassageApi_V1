using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MassageApi_V1.Models
{
    public class Shift
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }
        public int MassageTypeId { get; set; }
        public MassageType MassageType { get; set; }
    }
}
