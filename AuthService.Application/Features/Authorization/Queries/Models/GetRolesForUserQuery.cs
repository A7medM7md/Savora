using MediatR;
using AuthService.Application.Features.Authorization.Queries.Responses;
using AuthService.Domain.Commons;

namespace AuthService.Application.Features.Authorization.Queries.Models
{
    public class GetRolesForUserQuery : IRequest<Response<GetRolesForUserResponse>>
    {
        public int UserId { get; set; }
    }
}
