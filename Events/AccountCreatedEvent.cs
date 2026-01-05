using System;

namespace MicroservicesIntermediateStorage.Events
{
    public class AccountCreatedEvent
    {
        public int AccountId { get; set; }
        public string OwnerName { get; set; } = string.Empty;
        public decimal InitialBalance { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
