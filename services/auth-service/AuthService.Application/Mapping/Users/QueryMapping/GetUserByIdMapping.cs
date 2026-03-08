using AuthService.Application.Features.Users.Queries.Responses;
using AuthService.Domain.Entities.Identity;

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
