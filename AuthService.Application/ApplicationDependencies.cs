using AuthService.Application.Behaviors;
using AuthService.Application.Filters;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace AuthService.Application
{
    public static class ApplicationDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            // Configurations For Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            // Configurations For AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Get Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // Filter
            services.AddScoped<ValidateUserPermissionsFilter>();

            return services;
        }
    }
}
