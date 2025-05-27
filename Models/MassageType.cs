using System.ComponentModel.DataAnnotations;

namespace MassageApi_V1.Models
{
    public class MassageType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [StringLength(300)]
        public string Description { get; set; } = null!;
    }
}
