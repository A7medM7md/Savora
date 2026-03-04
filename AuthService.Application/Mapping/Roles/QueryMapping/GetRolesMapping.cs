using Microsoft.AspNetCore.Identity;
using AuthService.Application.Features.Authorization.Queries.Responses;

namespace AuthService.Application.Mapping.Roles
{
    public partial class RoleProfile
    {
        public void GetRolesMapping()
        {
            CreateMap<IdentityRole<int>, GetRolesResponse>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Name));
        }
    }
}
