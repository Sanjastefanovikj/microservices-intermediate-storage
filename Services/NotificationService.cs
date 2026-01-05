using MicroservicesIntermediateStorage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicesIntermediateStorage.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IIntermediateStorageService _intermediateStorage;

        public NotificationService(IIntermediateStorageService intermediateStorage)
        {
            _intermediateStorage = intermediateStorage;
        }

        public async Task<bool> SendNotificationAsync(Notification notification)
        {
            return await _intermediateStorage.SaveNotificationAsync(notification);
        }

        public async Task<Notification?> GetNotificationAsync(int notificationId)
        {
            return await _intermediateStorage.GetNotificationAsync(notificationId);
        }

        public async Task<IEnumerable<Notification>> GetNotificationsForAccountAsync(int accountId)
        {
            var allNotifications = await _intermediateStorage.GetAllNotificationsAsync();
            return allNotifications.Where(n => n.AccountId == accountId);
        }
    }
}
