using Chat.Domain;

namespace Chat.Service.Interface;

public interface IUserService
{
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUserById(int id);
    Task<User?> GetUserByLoginAndPassword(string login, string password);
    Task<int> CreateUser(User user);
    Task<int> DeleteUserById(int id);
    Task<int> UpdateUser(User user);
}