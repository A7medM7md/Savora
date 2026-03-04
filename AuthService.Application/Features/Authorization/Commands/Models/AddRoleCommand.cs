using MediatR;
using AuthService.Domain.Commons;

namespace AuthService.Application.Features.Authorization.Commands.Models
{
    public class AddRoleCommand : IRequest<Response<string>>
    {
        public string RoleName { get; set; }
    }
}
