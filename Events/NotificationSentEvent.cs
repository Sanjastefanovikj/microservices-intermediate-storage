using System;

namespace MicroservicesIntermediateStorage.Events
{
    public class NotificationSentEvent
    {
        public int NotificationId { get; set; }
        public int AccountId { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime SentAt { get; set; }
    }
}
