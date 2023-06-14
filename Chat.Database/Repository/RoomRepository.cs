using Chat.Database.Interface;
using Chat.Domain;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Chat.Database.Repository;

public class RoomRepository : IRoomRepository
{
    private readonly ChatDbContext _context;

    public RoomRepository(ChatDbContext context)
    {
        _context = context;
    }

    public async Task<int> Create(Room entity)
    {
        _context.Rooms.Add(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<Room> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Room>> GetAll()
    {
        return _context
            .Queryable<Room>().Include(x => x.Users)
            .AsNoTracking().ToList();
    }

    public async Task<int> DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> Update(Room entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Room>> GetByUserId(int id)
    {
        throw new NotImplementedException();
    }
}