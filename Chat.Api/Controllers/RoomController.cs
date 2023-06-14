using Chat.Api.Pages.Shared;
using Chat.Api.ViewModels;
using Chat.Domain;
using Chat.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers;

[Authorize]
[Route("/api/rooms")]
public class RoomController : Controller
{
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [Authorize]
    [HttpGet("index")]
    public async Task<IActionResult> Index()
    {
        return View(new Pages.Shared.IndexModel(await _roomService.GetRooms()));
    }

    [Authorize]
    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [Authorize]
    [HttpPost("create")]
    public async Task<IActionResult> Store(RoomModel room)
    {
        await _roomService.CreateRoom(new Room() { Title = room.Title});

        return RedirectToAction("Index", "Home");
    }
}