using Chat.Domain;

namespace Chat.Service.Interface;

public interface IRoomService
{
    Task<int> CreateRoom(Room room);
    Task<IEnumerable<Room>> GetRoomsByUserId(int id);
    Task<int> DeleteRoomById(int id);
    Task<int> UpdateRoom(Room room);
    Task<IEnumerable<Room>> GetRooms();
}