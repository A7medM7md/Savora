using AuthService.Application.Features.Users.Commands.Models;
using AuthService.Domain.Entities.Identity;

namespace AuthService.Application.Mapping.Users
{
    public partial class UserProfile
    {
        public void AddUserMapping()
        {
            CreateMap<AddUserCommand, AppUser>();
        }
    }
}
