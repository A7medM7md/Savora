using AuthService.Application.Abstractions.Services;
using AuthService.Services.Auth;
using AuthService.Services.Email;
using AuthService.Services.OAuth;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Services
{
    public static class ServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IPasswordResetService, PasswordResetService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            //services.AddScoped<IFileService, FileService>();
            services.AddScoped<IGoogleTokenValidator, GoogleTokenValidator>();

            return services;
        }
    }
}
