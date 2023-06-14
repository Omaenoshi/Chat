using Chat.Api.Pages.Shared;
using Chat.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers;

[Route("home")]
public class HomeController : Controller
{
    private readonly IRoomService _roomService;

    public HomeController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(new IndexModel(await _roomService.GetRooms()));
    }
}