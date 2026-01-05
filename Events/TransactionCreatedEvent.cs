using System;

namespace MicroservicesIntermediateStorage.Events
{
    public class TransactionCreatedEvent
    {
        public int TransactionId { get; set; }
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
