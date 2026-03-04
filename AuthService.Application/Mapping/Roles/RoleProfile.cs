using AutoMapper;

namespace AuthService.Application.Mapping.Roles
{
    public partial class RoleProfile : Profile
    {
        public RoleProfile()
        {
            GetRolesMapping();
            GetRoleByIdMapping();
        }
    }
}
