using Savora.Application.Common.Responses;
using Savora.Domain.Entities.Identity;
using Savora.Domain.Results;
namespace Savora.Application.Interfaces.Services
{
    public interface IIdentityService
    {
        Task<string?> GetUserNameAsync(string userId);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> AuthorizeAsync(string userId, string policyName);
        Task<bool> IsUserPhoneNumExist(string phoneNum);
        Task<bool> IsUserEmailExist(string email);


        Task<Result<int>> CreateUserAsync(User userData, string password, bool isConfirmed = false);

        Task<Result<UserSessionDto>> SignIn(string Email, string Password);
        Task<Result> SignOut();

        //Task<Result> DeleteUserAsync(string userId);
        Task<Result<UserSessionDto>> RefreshTokenAsync(string accessToken);

        ///////////////////////////////////////////////////////////////



    }
}
