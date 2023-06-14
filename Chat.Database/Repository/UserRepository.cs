using Chat.Database.Interface;
using Chat.Domain;
using Microsoft.EntityFrameworkCore;

namespace Chat.Database.Repository;

public class UserRepository : IUserRepository
{
    private readonly ChatDbContext _context;

    public UserRepository(ChatDbContext context)
    {
        _context = context;
    }

    public async Task<int> Create(User entity)
    {
        var userId = _context.Users.Add(new User
            { Name = entity.Name, Login = entity.Login, Password = entity.Password });
        await _context.SaveChangesAsync();

        return userId.Entity.Id;
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

    public async Task<User?> JoinToRoom(Room room, User user)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetByLoginAndPassword(string login, string password)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
    }
}