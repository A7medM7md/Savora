using MediatR;
using AuthService.Application.Features.Users.Queries.Responses;
using AuthService.Domain.Commons;

namespace AuthService.Application.Features.Users.Queries.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
