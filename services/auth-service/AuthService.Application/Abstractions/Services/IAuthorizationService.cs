using Microsoft.AspNetCore.Identity;
using AuthService.Application.Bases;
using AuthService.Application.Dtos;
using AuthService.Domain.Commons;

namespace AuthService.Application.Abstractions.Services
{
    public interface IAuthorizationService
    {
        #region Role Services

        public Task<IdentityResult> AddRoleAsync(string roleName);
        public Task<IdentityResult> EditRoleAsync(int id, string roleName);
        public Task<RoleResult> DeleteRoleAsync(int id);
        public Task<IdentityResult> AssignRoleAsync(int userId, string roleName);
        public Task<bool> IsRoleExist(string roleName, int? excludeId = null);

        public Task<IReadOnlyList<IdentityRole<int>>> GetRolesAsync(CancellationToken cancellationToken);
        public Task<IdentityRole<int>?> GetRoleByIdAsync(int id);
        public Task<Response<IReadOnlyList<RoleDto>>> GetRolesForUserAsync(int userId);

        public Task<IdentityResult> UpdateUserRolesAsync(int userId, IReadOnlyList<RoleDto> roles);

        #endregion

        #region Claim Services

        public Task<Response<List<ClaimDto>>> GetClaimsForUserAsync(int userId);
        public Task<IdentityResult> UpdateUserClaimsAsync(int userId, List<ClaimDto> claims);


        #endregion

    }
}
