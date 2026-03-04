using MediatR;
using AuthService.Application.Features.Authorization.Queries.Responses;
using AuthService.Domain.Commons;

namespace AuthService.Application.Features.Authorization.Queries.Models
{
    public class GetClaimsForUserQuery : IRequest<Response<GetClaimsForUserResponse>>
    {
        public int UserId { get; set; }
    }
}
