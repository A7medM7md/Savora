

using Microsoft.Extensions.DependencyInjection;
using Savora.Application.Persistence.Contexts;
using Savora.Domain.Entities;

namespace Savora.Application.Services.ApplicationUser
{
    public class AuditLoggerService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        //private readonly Context _context;

        public AuditLoggerService(IServiceScopeFactory serviceScopeFactory)
        {
            _scopeFactory = serviceScopeFactory;
        }

        public async Task LogAsync(string action, string entityName, int? entityId = null, int? userId = null)
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SavoraContext>();
            var log = new AuditLog
            {
                Action = action,
                EntityName = entityName,
                EntityId = entityId,
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };

            await context.AuditLogs.AddAsync(log);
            await context.SaveChangesAsync();
        }
    }
}
