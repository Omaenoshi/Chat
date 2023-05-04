using Chat.Database.Interface;
using Chat.Domain.Entity;

namespace Chat.Database.Repository;

public class RoomRepository : IRoomRepository
{
    public bool Create(Room entity)
    {
        throw new NotImplementedException();
    }

    public Task<Room> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Room>> GetAll()
    {
        throw new NotImplementedException();
    }

    public bool Delete(Room entity)
    {
        throw new NotImplementedException();
    }
}