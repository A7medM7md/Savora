using AuthService.Application.Features.Users.Commands.Models;
using AuthService.Domain.Entities.Identity;

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
