using Chat.Database.Interface;
using Chat.Domain.Entity;

namespace Chat.Database.Repository;

public class UserRepository : IBaseRepository<User>
{
    public bool Create(User entity)
    {
        throw new NotImplementedException();
    }

    public User GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public bool Delete(User entity)
    {
        throw new NotImplementedException();
    }
}