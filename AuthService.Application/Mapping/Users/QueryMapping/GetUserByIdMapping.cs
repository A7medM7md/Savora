using AuthService.Application.Entities.Identity;
using AuthService.Application.Features.Users.Queries.Responses;

namespace AuthService.Application.Mapping.Users
{
    public partial class UserProfile
    {
        public void GetUserByIdMapping()
        {
            CreateMap<AppUser, GetUserByIdResponse>();
        }
    }
}
