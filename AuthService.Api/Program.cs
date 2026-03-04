using AuthService.Api;
using AuthService.Application.Entities.Identity;
using AuthService.Application.Middlewares;
using AuthService.Infrastructure.DataSeeding;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add Controllers and Swagger/OpenAPI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAppDependencies(builder.Configuration);

// Add Cross Origin
builder.Services.AddCors(options =>
{
    options.AddPolicy("allowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region AdminUser, Roles Seeding

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole<int>>>();

    await RoleSeeder.SeedAsync(roleManager);
    await UserSeeder.SeedAsync(userManager, roleManager);
}

#endregion

#region Request Localization Middleware

var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);

#endregion 

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseCors("allowAll");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.Run();
