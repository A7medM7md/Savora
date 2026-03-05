using Microsoft.EntityFrameworkCore;
using NotificationService.Domain.Entities;

namespace NotificationService.Infrastructure.Persistence.Contexts
{
    public class SavoraNotificationsContext(DbContextOptions<SavoraNotificationsContext> options) : DbContext(options)
    {
        public DbSet<Notification> Notifications { get; set; }
    }
}
