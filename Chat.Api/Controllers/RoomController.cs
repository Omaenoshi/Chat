using Chat.Domain.Entity;
using Chat.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers;

[ApiController]
[Route("/api/rooms")]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpPost]
    public async Task<int> Create(Room room)
    {
        return await _roomService.CreateRoom(room);
    }

    [HttpGet("user/{id}")]
    public async Task<IEnumerable<Room>> GetByUserId(int id)
    {
        return await _roomService.GetRoomsByUserId(id);
    }
}