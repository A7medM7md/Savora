using MediatR;
using AuthService.Domain.Commons;
using System.Text.Json.Serialization;

namespace AuthService.Application.Features.Authorization.Commands.Models
{
    public class AssignRoleCommand : IRequest<Response<string>>
    {
        [JsonIgnore]
        public int UserId { get; set; }
        public string RoleName { get; set; }
    }
}
