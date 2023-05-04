using Chat.Database.Interface;
using Chat.Domain;

namespace Chat.Database.Repository;

public class UserRepository : IUserRepository
{
    public async Task<int> Create(User entity)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> Update(User entity)
    {
        throw new NotImplementedException();
    }
}