using Chat.Api.Pages.Shared;
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

    

    [HttpGet("index")]
    public async Task<IActionResult> Index()
    {
        return View(new IndexModel(await _roomService.GetRooms()));
    }
}