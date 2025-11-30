//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Savora.Application.Common.Responses;
using Savora.Application.Interfaces.Services;
using Savora.Application.Persistence.Contexts;
using Savora.Domain.Entities.Identity;
using Savora.Domain.Enums;
using Savora.Domain.Helpers;
using Savora.Domain.Results;

namespace Savora.Application.Services.ApplicationUser
{
    public class IdentityService(
    UserManager<User> userManager,
    SavoraContext context,
    ITokensService tokensService,
    JwtSettings jwtSettings,
    IHttpContextAccessor _httpContextAccessor,
    ILogger<IdentityService> _logger,
    IUserClaimsPrincipalFactory<User> userClaimsPrincipalFactory,
    IAuthorizationService authorizationService) : IIdentityService

    {
        public async Task<string?> GetUserNameAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            return user?.UserName;
        }

        public async Task<bool> IsInRoleAsync(string userId, string role)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == int.Parse(userId));


            return user != null && await userManager.IsInRoleAsync(user, role);
        }

        public async Task<bool> AuthorizeAsync(string userId, string policyName)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == int.Parse(userId));

            if (user == null)
            {
                return false;
            }

            var principal = await userClaimsPrincipalFactory.CreateAsync(user);

            var result = await authorizationService.AuthorizeAsync(principal, policyName);

            return result.Succeeded;
        }

        /*public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            return user != null ? await DeleteUserAsync(user) : Result.Success();
        }*/

        /*public async Task<Result> DeleteUserAsync(User user)
        {
            var result = await userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }*/

        public Task<bool> IsUserPhoneNumExist(string phoneNum)
        {
            return userManager.Users.IgnoreQueryFilters()
                .AnyAsync(u => u.PhoneNumber == phoneNum);
        }

        public Task<bool> IsUserEmailExist(string email)
        {
            return userManager.Users.IgnoreQueryFilters()
                .AnyAsync(u => u.Email!.ToLower() == email.ToLower());
        }

        public async Task<Result<int>> CreateUserAsync(User userData, string password, bool isConfirmed = false)
        {

            if (isConfirmed)
            {
                userData.ConfirmEmail();
                //userData.ConfirmPhone();
            }

            var res = await userManager.CreateAsync(userData, password);

            if (res.Succeeded)
                return userData.Id;

            var firstError = res.Errors.Select(e => e.Description).FirstOrDefault() ?? "An error occurred during user creation.";

            return new Error(ErrorCode.FailedToCreateData, firstError);
        }

        public async Task<Result<UserSessionDto>> SignIn(string email, string password)
        {
            var user = await userManager.Users.IgnoreQueryFilters().FirstOrDefaultAsync(u => u.Email!.ToLower() == email.ToLower());

            if (user == null)
            {
                return ErrorCode.InvalidCredentials;
            }
            if (!user.EmailConfirmed)
            {
                return ErrorCode.EmailNotConfirmed;
            }

            var validPass = await userManager.CheckPasswordAsync(user, password);




            if (!validPass)
            {
                return ErrorCode.InvalidCredentials;
            }


            var tokenGenRes = await tokensService.GenerateTokensAsync(user);

            if (!tokenGenRes.IsSuccess)
                return tokenGenRes.Error;



            var response = new UserSessionDto
            {
                UserId = user.Id,
                Name = user.Name,
                Email = user.Email!,
                AccessToken = tokenGenRes.Data!.AccessToken,
                AccessTokenExpDate = tokenGenRes.Data!.AccessTokenExpiry,
                RefreshTokenExpDate = tokenGenRes.Data!.RefreshTokenExpiry
            };

            return Result.Success(response);
        }

        public Task<Result> SignOut() => tokensService.RemoveRefreshTokenAsync();


        public async Task<Result<UserSessionDto>> RefreshTokenAsync(string accessToken)
        {
            TokenData tokenGenRes;
            var res = await tokensService.RefreshAsync(accessToken);
            if (!res.IsSuccess || res.Data is null)
            {
                return res.Error;
            }

            tokenGenRes = res.Data;

            var user = await userManager.Users.IgnoreQueryFilters().FirstOrDefaultAsync(u => u.Id == int.Parse(tokenGenRes.UserId.ToString()));

            if (user == null)
                return ErrorCode.UserNotFound;

            return new UserSessionDto
            {
                UserId = user.Id,
                Name = user.Name,
                Email = user.Email!,
                AccessToken = tokenGenRes.AccessToken,

                AccessTokenExpDate = tokenGenRes.AccessTokenExpiry,
                RefreshTokenExpDate = tokenGenRes.RefreshTokenExpiry
            };
        }
        /////////////////////////////////////////////////////////
        ///


    }
}
