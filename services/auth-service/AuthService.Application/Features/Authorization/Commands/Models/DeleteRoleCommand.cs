using MediatR;
using AuthService.Domain.Commons;

namespace AuthService.Application.Features.Authorization.Commands.Models
{
    public class DeleteRoleCommand : IRequest<Response<string>>
    {
        public DeleteRoleCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
