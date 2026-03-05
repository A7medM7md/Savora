using MediatR;
using AuthService.Application.Features.Users.Queries.Responses;
using AuthService.Application.Wrappers;

namespace AuthService.Application.Features.Users.Queries.Models
{
    public class GetPaginatedUsersQuery : IRequest<PaginatedResult<GetPaginatedUsersResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
