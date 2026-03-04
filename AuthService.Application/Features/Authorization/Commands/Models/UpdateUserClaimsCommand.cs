using MediatR;
using AuthService.Application.Dtos;
using AuthService.Domain.Commons;
using System.Text.Json.Serialization;

namespace AuthService.Application.Features.Authorization.Commands.Models
{
    public class UpdateUserClaimsCommand : IRequest<Response<string>>
    {
        [JsonIgnore]
        public int UserId { get; set; }
        public List<ClaimDto> Claims { get; set; } = new();
    }
}
