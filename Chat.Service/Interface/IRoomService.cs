using Chat.Domain.Entity;

namespace Chat.Service.Interface;

public interface IRoomService
{
    Task<int> CreateRoom(Room room);
    Task<IEnumerable<Room>> GetRoomsByUserId(int id);
    Task<int> DeleteRoomById(int id);
}