﻿using Chat.Database.Interface;
using Chat.Database.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Database;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ChatDbContext>(options =>
        {
            options.UseNpgsql(connectionString,
                o => o.UseNodaTime());
        });
        services.AddScoped<ChatDbContext>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IRoomRepository, RoomRepository>();
        services.AddTransient<IMessageRepository, MessageRepository>();
        return services;
    }
}