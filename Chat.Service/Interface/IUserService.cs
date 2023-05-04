using Chat.Domain.Entity;

namespace Chat.Service.Interface;

public interface IUserService
{
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUserById(int id);
    bool CreateUser(User user);
}