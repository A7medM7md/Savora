using MediatR;
using AuthService.Application.Dtos;
using AuthService.Domain.Commons;
using System.Text.Json.Serialization;

namespace AuthService.Application.Features.Authorization.Commands.Models
{
    public class UpdateUserRolesCommand : IRequest<Response<string>>
    {
        [JsonIgnore]
        public int UserId { get; set; }
        public IReadOnlyList<RoleDto>? Roles { get; set; }
    }
}
