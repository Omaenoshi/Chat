using Chat.Domain.Entity;

namespace Chat.Database.Interface;

public interface IRoomRepository : IBaseRepository<Room>
{
    Task<IEnumerable<Room>> GetByUserId(int id);
}