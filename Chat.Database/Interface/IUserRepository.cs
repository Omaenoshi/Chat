using Chat.Domain;

namespace Chat.Database.Interface;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByLoginAndPassword(string login, string password);
}