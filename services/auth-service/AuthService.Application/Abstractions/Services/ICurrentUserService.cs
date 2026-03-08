using AuthService.Domain.Entities.Identity;

namespace AuthService.Application.Abstractions.Services
{
    public interface ICurrentUserService
    {
        public Task<AppUser> GetCurrentUserAsync();
        public int GetCurrentUserId();
        public Task<IList<string>> GetCurrentUserRolesAsync();
    }
}
