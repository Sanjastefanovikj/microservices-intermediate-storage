namespace MicroservicesIntermediateStorage.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public int AccountId { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime SentAt { get; set; }
    }
}
