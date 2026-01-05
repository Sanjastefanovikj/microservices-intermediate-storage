using MicroservicesIntermediateStorage.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicesIntermediateStorage.Services
{
    public interface INotificationService
    {
        Task<bool> SendNotificationAsync(Notification notification);
        Task<Notification?> GetNotificationAsync(int notificationId);
        Task<IEnumerable<Notification>> GetNotificationsForAccountAsync(int accountId);
    }
}
