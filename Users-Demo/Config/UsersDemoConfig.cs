using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Users_Demo.Common.Requests.CommonRequest;
using Users_Demo.Common.Requests.University;
using Users_Demo.Common.Requests.Users;
using Users_Demo.DAL;
using Users_Demo.DAL.Models;
using Users_Demo.Filter;
using Users_Demo.Repository.Implementation;
using Users_Demo.Repository.Interface;
using Users_Demo.Services.Implementation;
using Users_Demo.Services.Interface;
using Users_Demo.Validator.CommonValidator;
using Users_Demo.Validator.Models.University;
using Users_Demo.Validator.Models.Users;

namespace Users_Demo.Config
{
    internal static class UsersDemoConfig
    {
        internal static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUniversityService, UniversityService>();
            services.AddTransient<IRepository, Repository<UsersDemoContext>>();
        }

        internal static void AddValidator(this IServiceCollection services)
        {
            services.AddMvc(options => { options.Filters.Add<ValidationFilter>(); }).AddFluentValidation();
            services.AddModelValidator();
        }

        private static void AddModelValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<RequestById>, RequestByIdValidator>();

            services.AddTransient<IValidator<Users>, UsersModelValidator>();
            services.AddTransient<IValidator<UsersByFirstName>, UsersByFirstNameValidator>();
            services.AddTransient<IValidator<UsersByLastName>, UsersByLastNameValidator>();

            services.AddTransient<IValidator<UniversityByName>, UniversityByNameValidator>();
            services.AddTransient<IValidator<University>, UniversityModelValidator>();

        }
    }
}
