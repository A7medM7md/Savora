using AuthService.Application.Entities.Identity;
using AuthService.Application.Features.Users.Commands.Models;

namespace AuthService.Application.Mapping.Users
{
    public partial class UserProfile
    {
        public void EditUserMapping()
        {
            CreateMap<EditUserCommand, AppUser>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
