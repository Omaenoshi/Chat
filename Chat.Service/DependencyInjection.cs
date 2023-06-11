using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Chat.Service.Implementation;
using Chat.Service.Interface;

namespace Chat.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection Addapplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}
