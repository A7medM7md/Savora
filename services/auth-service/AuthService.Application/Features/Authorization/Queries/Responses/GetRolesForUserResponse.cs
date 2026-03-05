using AuthService.Application.Dtos;

namespace AuthService.Application.Features.Authorization.Queries.Responses
{
    public class GetRolesForUserResponse
    {
        public int UserId { get; set; }
        public IReadOnlyList<RoleDto>? Roles { get; set; }
    }
}
