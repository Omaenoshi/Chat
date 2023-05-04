using Chat.Database.Interface;
using Chat.Domain.Entity;

namespace Chat.Database.Repository;

public class RoomRepository : IRoomRepository
{
    public async Task<int> Create(Room entity)
    {
        throw new NotImplementedException();
    }

    public async Task<Room> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Room>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> Update(Room entity)
    {
        throw new NotImplementedException();
    }
}