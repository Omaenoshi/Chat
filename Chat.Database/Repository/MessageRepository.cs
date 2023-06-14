using Chat.Database.Interface;
using Chat.Domain;
using Microsoft.EntityFrameworkCore;

namespace Chat.Database.Repository;

public class MessageRepository : IMessageRepository
{
    private readonly ChatDbContext _context;

    public MessageRepository(ChatDbContext context)
    {
        _context = context;
    }

    public async Task<int> Create(int userId, int roomId, string text)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == userId);
        var room = _context.Rooms.FirstOrDefault(x => x.Id == roomId);
        var message = new Message { Room = room, Text = text, User = user };
        _context.Messages.Add(message);
        return await _context.SaveChangesAsync();
    }

    public Task<int> Create(Message entity)
    {
        throw new NotImplementedException();
    }

    public Task<Message> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Message>> GetAll()
    {
        return _context
            .Queryable<Message>().Include(x => x.User)
            .AsNoTracking().ToList();
    }

    public Task<int> DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> Update(Message entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Message>> GetByRoomId(int id)
    {
        return _context
            .Queryable<Message>()
            .Include(x => x.User)
            .Include(x => x.Room)
            .Where(x => x.Room.Id == id)
            .AsNoTracking()
            .ToList();
    }
}