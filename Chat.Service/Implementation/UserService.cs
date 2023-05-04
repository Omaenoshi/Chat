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

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _userRepository.GetAll();
    }

    public async Task<User> GetUserById(int id)
    {
        return await _userRepository.GetById(id);
    }

    public async Task<int> CreateUser(User user)
    {
        return await _userRepository.Create(user);
    }

    public async Task<int> DeleteUserById(int id)
    {
        return await _userRepository.DeleteById(id);
    }

    public async Task<int> UpdateUser(User user)
    {
        return await _userRepository.Update(user);
    }
}