using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Savora.Application.Interfaces.Services;
using Savora.Application.Persistence.Contexts;
using Savora.Application.Services.ApplicationUser;
using Savora.Domain.Entities.Identity;
using Savora.Domain.Helpers;
using System.Text;
using UserService.Services.Abstracts;

namespace Savora.Application
{
    public static class InfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Connection To SQL Server
            services.AddDbContext<SavoraContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient<AuditLoggerService>();
            // services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ICookieManager, CookieManager>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddScoped<IEmailConfirmationService, EmailConfirmationService>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<ITokenValidator, TokenValidator>();
            services.AddScoped<ITokensService, TokensService>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped(typeof(Lazy<>));
            // services.AddScoped<PaymentService>();

            services.AddHttpClient();
            services.AddHttpContextAccessor();

            // Service Registeration
            services.AddIdentity<User, IdentityRole<int>>(option =>
            {
                // Password settings.
                option.Password.RequireDigit = true;
                option.Password.RequireLowercase = true;
                option.Password.RequireNonAlphanumeric = true;
                option.Password.RequireUppercase = true;
                option.Password.RequiredLength = 6;
                option.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                option.Lockout.MaxFailedAccessAttempts = 5;
                option.Lockout.AllowedForNewUsers = true;

                // User settings.
                option.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                option.User.RequireUniqueEmail = true;
                option.SignIn.RequireConfirmedEmail = true;

            }).AddEntityFrameworkStores<SavoraContext>().AddDefaultTokenProviders();

            //JWT Authentication
            var jwtSettings = new JwtSettings();
            var emailSettings = new EmailSettings();
            configuration.GetSection(nameof(jwtSettings)).Bind(jwtSettings);
            configuration.GetSection(nameof(emailSettings)).Bind(emailSettings);

            services.AddSignalR();


            services.AddSingleton(jwtSettings);
            services.AddSingleton(emailSettings);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = jwtSettings.validateIssuer,
                   ValidIssuers = new[] { jwtSettings.issuer },
                   ValidateIssuerSigningKey = jwtSettings.validateIssuerSigningKey,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.secret)),
                   ValidAudience = jwtSettings.audience,
                   ValidateAudience = jwtSettings.validateAudience,
                   ValidateLifetime = jwtSettings.validateLifetime,
               };
           });

            return services;
        }
    }
}
