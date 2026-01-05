namespace MicroservicesIntermediateStorage.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string OwnerName { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
