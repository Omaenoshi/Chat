using Chat.Domain;
using Chat.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers;

[Route("/api/rooms")]
public class RoomController : Controller
{
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpGet]
    public async Task<IEnumerable<Room>> Get()
    {
        return await _roomService.GetRooms();
    }

    [HttpPost]
    public async Task<int> Create(Room room)
    {
        return await _roomService.CreateRoom(room);
    }

    [HttpGet("users/{id}")]
    public async Task<IEnumerable<Room>> GetByUserId(int id)
    {
        return await _roomService.GetRoomsByUserId(id);
    }

    [HttpDelete("{id}")]
    public async Task<int> Delete(int id)
    {
        return await _roomService.DeleteRoomById(id);
    }

    [HttpPut]
    public async Task<int> Update(Room room)
    {
        return await _roomService.UpdateRoom(room);
    }
}