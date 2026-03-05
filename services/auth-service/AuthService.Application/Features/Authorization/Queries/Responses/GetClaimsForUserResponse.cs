using AuthService.Application.Dtos;

namespace AuthService.Application.Features.Authorization.Queries.Responses
{
    public class GetClaimsForUserResponse
    {
        public int UserId { get; set; }
        public List<ClaimDto> Claims { get; set; } = new();
    }
}
