using Chat.Service.Implementation;
using Chat.Service.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Service;

public static class DependencyInjection
{
    public static IServiceCollection Addapplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IRoomService, RoomService>();
        services.AddTransient<IMessageService, MessageService>();
        services.AddTransient<WebSocketHandler, WebSocketHandler>();
        services.AddTransient<WebSocketConnectionManager, WebSocketConnectionManager>();
        return services;
    }
}