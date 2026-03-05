using Microsoft.AspNetCore.SignalR;


namespace NotificationService.Infrastructure.Notifications
{
    public class NotificationHub : Hub
    {
        public async Task SendMessage(long userId, string message)
        {
            await Clients.User(userId.ToString()).SendAsync("ReceiveNotification", message);
        }
    }
}
