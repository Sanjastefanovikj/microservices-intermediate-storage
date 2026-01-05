using Microsoft.AspNetCore.Mvc;
using MicroservicesIntermediateStorage.Models;
using MicroservicesIntermediateStorage.Services;
using System.Threading.Tasks;

namespace MicroservicesIntermediateStorage.Controllers
{
    [ApiController]
    [Route("api/notifications")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendNotification([FromBody] Notification notification)
        {
            var result = await _notificationService.SendNotificationAsync(notification);
            if (result)
                return Ok(new { message = "Notification sent successfully" });
            return BadRequest(new { message = "Failed to send notification" });
        }

        [HttpGet("{notificationId}")]
        public async Task<IActionResult> GetNotification(int notificationId)
        {
            var notification = await _notificationService.GetNotificationAsync(notificationId);
            if (notification == null)
                return NotFound();
            return Ok(notification);
        }

        [HttpGet("account/{accountId}")]
        public async Task<IActionResult> GetNotificationsForAccount(int accountId)
        {
            var notifications = await _notificationService.GetNotificationsForAccountAsync(accountId);
            return Ok(notifications);
        }
    }
}
