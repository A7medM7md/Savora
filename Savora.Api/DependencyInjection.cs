using Microsoft.AspNetCore.Localization;
using Savora.Application;
using Savora.Application;
using System.Globalization;

namespace Savora.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructureDependencies(configuration) // DbContext, Repositories
                .AddApplicationDependencies();


            #region Configure Localization

            services.AddLocalization();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("de-DE"),
                    new CultureInfo("fr-FR"),
                    new CultureInfo("ar-EG")
                };

                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            #endregion

            #region Identity and Authentication

            //// Add Identity With Configurations
            //services.AddIdentity<AppUser, IdentityRole<int>>(options =>
            //{
            //    // lockout settings
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //    options.Lockout.MaxFailedAccessAttempts = 5;

            //    // signIn settings
            //    options.SignIn.RequireConfirmedEmail = true;

            //    // user settings
            //    options.User.RequireUniqueEmail = true;

            //    // password settings
            //    options.Password.RequireDigit = true;
            //    options.Password.RequireNonAlphanumeric = true;
            //})
            //.AddEntityFrameworkStores<ApplicationDbContext>()
            //.AddDefaultTokenProviders();


            //// JWT Authentication
            //var jwtSettings = new JWTSettings();
            //configuration.GetSection(nameof(JWTSettings)).Bind(jwtSettings);
            //services.AddSingleton(jwtSettings);


            //services.AddAuthentication(config =>
            //{
            //    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(config =>
            //{
            //    config.RequireHttpsMetadata = false;
            //    config.SaveToken = true;
            //    config.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = jwtSettings.ValidateIssuer,
            //        ValidIssuer = jwtSettings.Issuer,
            //        ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            //        ValidAudience = jwtSettings.Audience,
            //        ValidateAudience = jwtSettings.ValidateAudience,
            //        ValidateLifetime = jwtSettings.ValidateLifetime,
            //        ClockSkew = TimeSpan.Zero, // By Default He Adds 5 Min On Expiry, This Line Prevent That
            //        RoleClaimType = ClaimTypes.Role
            //    };
            //});

            #endregion

            #region Configure Authorization Policy [Roels & Claims]

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Admin", policy =>
            //    // Mixed Conditions [Claim, Role, Custom]..
            //        policy.RequireAssertion(context =>
            //            context.User.IsInRole("Admin") &&
            //            context.User.HasClaim("Can Create Student", "true") &&
            //            DateTime.Now.Hour < 18 // Only Before 6 PM
            //        )
            //    );

            //    // Simpler Than Above [Conditions On Claim]..
            //    options.AddPolicy("CreateStudent", policy =>
            //        policy.RequireClaim("Can Create Student", "true")
            //    );

            //    options.AddPolicy("EditStudent", policy =>
            //        policy.RequireClaim("Can Edit Student", "true")
            //    );

            //    options.AddPolicy("DeleteStudent", policy =>
            //        policy.RequireClaim("Can Delete Student", "true")
            //    );

            //    options.AddPolicy("CreateAndEditStudent", policy =>
            //        policy.RequireClaim("Can Create Student", "true")
            //            .RequireClaim("Can Edit Student", "true")
            //    );

            //    options.AddPolicy("AdminCanCreateStudent", policy =>
            //        policy.RequireClaim("Can Create Student", "true")
            //            .RequireRole("Admin")
            //    );

            //});

            #endregion

            #region Swagger Gen
            services.AddSwaggerGen();
            #endregion

            // Bind EmailSettings From appsettings.json
            //services.Configure<EmailSettings>(configuration.GetSection(nameof(EmailSettings)));

            #region Serilog

            //Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Debug()
            //    .ReadFrom.Configuration(configuration)
            //    .CreateLogger();

            //services.AddSerilog();

            #endregion

            return services;
        }
    }
}
