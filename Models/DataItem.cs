namespace MicroservicesIntermediateStorage.Models
{
    public class DataItem
    {
        public int Id { get; set; }
        public string Data { get; set; } = string.Empty;
        public DateTime LastUpdated { get; set; }
    }
}
