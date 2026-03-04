using AutoMapper;

namespace AuthService.Application.Mapping.Users
{
    public partial class UserProfile : Profile
    {
        public UserProfile()
        {
            GetUserByIdMapping();
            AddUserMapping();
            EditUserMapping();
        }
    }
}
