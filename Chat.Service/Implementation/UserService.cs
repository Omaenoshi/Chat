using Chat.Database.Interface;
using Chat.Domain.Entity;
using Chat.Service.Interface;

namespace Chat.Service.Implementation;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<IEnumerable<User>> GetUsers()
    {
        return _userRepository.GetAll();
    }

    public Task<User> GetUserById(int id)
    {
        return _userRepository.GetById(id);
    }

    public bool CreateUser(User user)
    {
        return _userRepository.Create(user);
    }
}