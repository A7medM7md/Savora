using Microsoft.AspNetCore.Identity;

namespace AuthService.Application.Bases
{
    public enum RoleStatus
    {
        Success,
        NotFound,
        AlreadyExists,
        HasUsers,
        Failed
    }

    public class RoleResult
    {
        public RoleStatus Status { get; set; }
        public IdentityResult? IdentityResult { get; set; }
        public IdentityRole<int>? Role { get; set; }
    }
}
