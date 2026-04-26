using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.OpenApi;
using System.Globalization;


namespace ExpenseService.Api
{
    public static class AppDependencies
    {
        public static IServiceCollection AddAppDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddInfrastructureDependencies(configuration)
            //    .AddServiceDependencies()
            //    .AddCoreDependencies();

            #region Configure Localization

            services.AddLocalization();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("ar-EG"),
                    //new CultureInfo("de-DE"),
                    //new CultureInfo("fr-FR")
                };

                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });


            #endregion


            #region Swagger Gen

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                { Title = "Savora expense-service", Version = "1.0.0" });
                c.EnableAnnotations();

                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef...')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });

                // c.AddSecurityRequirement(new OpenApiSecurityRequirement
                // {
                //     {
                //         new OpenApiSecurityScheme
                //         {
                //             Reference = new OpenApiReference
                //             {
                //                 Type = ReferenceType.SecurityScheme,
                //                 Id = JwtBearerDefaults.AuthenticationScheme
                //             }
                //         },
                //         Array.Empty<string>()
                //     }
                //});
            });

            #endregion


            #region Serilog

            ///Log.Logger = new LoggerConfiguration()
            ///    .MinimumLevel.Debug()
            ///    .WriteTo.Console() // Log In Console
            ///    .WriteTo.File("logs/myapp.txt") // Log In File
            ///    .WriteTo.MSSqlServer(
            ///        connectionString: configuration.GetConnectionString("DefaultConnection"),
            ///        tableName: "Logs",
            ///        autoCreateSqlTable: true) // Log In DB
            ///    .CreateLogger();

            // OR [Better ==> From appsettings.json]

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
