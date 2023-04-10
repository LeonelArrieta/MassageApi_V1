using System.ComponentModel.DataAnnotations.Schema;

namespace MassageApi_V1.Models
{
    public class Shift
    {
        public int Id { get; set; }

        [Column(TypeName ="datetime")]
        public DateTime Date { get; set; }

        public int ContactId { get; set; }
        public Contact contact { get; set; } = null!;
        public int MassageTypeId { get; set; }
        public MassageType massageType { get; set; } = null!;
    }
}
