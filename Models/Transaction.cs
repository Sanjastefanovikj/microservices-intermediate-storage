namespace MicroservicesIntermediateStorage.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
