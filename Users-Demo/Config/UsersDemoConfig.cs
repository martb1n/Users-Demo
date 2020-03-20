using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Users_Demo.DAL.Models;
using Users_Demo.Services.Implementation;
using Users_Demo.Services.Interface;
using Users_Demo.Validator.Models;

namespace Users_Demo.Config
{
    internal static class UsersDemoConfig
    {
        internal static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }

        internal static void AddValidator(this IServiceCollection services)
        {
            services.AddMvc(options => { }).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddTransient<IValidator<Users>, UsersModelValidator>();
        }
    }
}
