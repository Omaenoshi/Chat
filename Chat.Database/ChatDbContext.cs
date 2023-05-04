using Chat.Domain;
using Microsoft.EntityFrameworkCore;

namespace Chat.Database;

public class ChatDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Message> Messages { get; set; }

    public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}