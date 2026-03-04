using Grpc.Core;
using Microsoft.AspNetCore.SignalR;
using NotificationService.Domain.Entities;
using NotificationService.Infrastructure.Notifications;
using NotificationService.Infrastructure.Persistence.Contexts;
using NotificationService.Infrastructure.Protos;

namespace NotificationService.Api.Grpc
{
    public class NotifierService(IHubContext<NotificationHub> hubContext, ILogger<NotifierService> logger, SavoraNotificationsContext db) : Notifier.NotifierBase
    {
        public override async Task<SendNotificationResponse> SendNotification(SendNotificationRequest request, ServerCallContext context)
        {
            try
            {
                var userIds = request.UserIds.ToList();
                var message = request.Message;
                var eventName = request.EventName;
                var recipientEmail = request.RecipientEmail;
                var notificationPayload = new
                {
                    Message = message,
                    Data = request.Data
                };
                var jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(notificationPayload);

                logger.LogInformation("Sending notification to users: {UserIds}", string.Join(", ", userIds));

                foreach (var userId in userIds)
                {
                    //sava in db
                    var notificationEntity = new Notification
                    {
                        UserId = long.Parse(userId),
                        Message = message,
                        CreatedAt = DateTime.UtcNow
                    };
                    await db.Notifications.AddAsync(notificationEntity);
                    await hubContext.Clients.User(userId)
                        .SendAsync(eventName, notificationPayload);
                }

                await db.SaveChangesAsync();
                return new SendNotificationResponse { Success = true };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error sending notification via gRPC.");
                return new SendNotificationResponse { Success = false };
            }
        }
    }
}
