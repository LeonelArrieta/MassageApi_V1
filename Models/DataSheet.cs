namespace MassageApi_V1.Models
{
    public class DataSheet
    {
        public int Id { get; set; }
        public string Observation { get; set; } = null!;
        public int ContactId { get; set; }
    }
}
