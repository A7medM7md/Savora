using MediatR;
using AuthService.Application.Features.Authorization.Queries.Responses;
using AuthService.Domain.Commons;

namespace AuthService.Application.Features.Authorization.Queries.Models
{
    public class GetRoleByIdQuery : IRequest<Response<GetRoleByIdResponse>>
    {
        public int Id { get; set; }
    }
}
