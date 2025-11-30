namespace UserService.Core.Features.Auth.Dto;

public record CreateUserRequest
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; }
    public string BaseCurrency { get; set; }
    public decimal MonthlySalary { get; set; }
    public int MonthlyDate { get; set; }
}
