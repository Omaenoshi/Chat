using Chat.Domain.Entity;

namespace Chat.Service.Interface;

public interface IUserService
{
    IEnumerable<User> GetUsers();
}