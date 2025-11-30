
using Savora.Domain.Entities.Identity;
using UserService.Core.Features.Auth.Dto;

namespace Savora.Application.Features.Auth.Commands.RegisterFeature.Extensions;
public static class UserExtensions
{
    public static User ToEntity(this CreateUserRequest userRequest) => new User
    {
        Name = userRequest.Name,
        Email = userRequest.Email,
        UserName = userRequest.Email,
        PhoneNumber = userRequest.PhoneNumber,
        CreatedAt = DateTime.UtcNow,
        Address = userRequest.Address,
        BaseCurrency = userRequest.BaseCurrency,
        MonthlySalary = userRequest.MonthlySalary,
        MonthlyDate = userRequest.MonthlyDate,
    };
}