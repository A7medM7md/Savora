using AuthService.Application.Entities.Identity;
using AuthService.Application.Features.Users.Commands.Models;

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
