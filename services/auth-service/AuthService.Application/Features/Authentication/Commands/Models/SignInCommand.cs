using AuthService.Domain.Commons;
using AuthService.Domain.Helpers.JWT;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AuthService.Application.Features.Authentication.Commands.Models
{
    public class SignInCommand : IRequest<Response<SignInResponse>>
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
