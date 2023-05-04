using Chat.Database.Interface;
using Chat.Domain;
using Chat.Service.Interface;

namespace Chat.Service.Implementation;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;

    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<int> CreateRoom(Room room)
    {
        return await _roomRepository.Create(room);
    }

    public async Task<IEnumerable<Room>> GetRoomsByUserId(int id)
    {
        return await _roomRepository.GetByUserId(id);
    }

    public async Task<int> DeleteRoomById(int id)
    {
        return await _roomRepository.DeleteById(id);
    }

    public async Task<int> UpdateRoom(Room room)
    {
        return await _roomRepository.Update(room);
    }
}

