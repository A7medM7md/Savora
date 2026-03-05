using MediatR;
using AuthService.Application.Features.Authorization.Queries.Responses;
using AuthService.Domain.Commons;

namespace AuthService.Application.Features.Authorization.Queries.Models
{
    public class GetRolesQuery : IRequest<Response<IReadOnlyList<GetRolesResponse>>>
    {
    }
}
