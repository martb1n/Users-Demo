using Microsoft.Extensions.DependencyInjection;
using Users_Demo.Repository.Implementation;
using Users_Demo.Repository.Interface;
using Users_Demo.Services.Implementation;
using Users_Demo.Services.Interface;

namespace Users_Demo.Config
{
    public static class UsersDemoConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
