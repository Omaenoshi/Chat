using System.Security.Claims;
using Chat.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers;

[Authorize]
[Route("/api/messages")]
public class MessageController : Controller
{
    private readonly IMessageService _messageService;

    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [Authorize]
    [HttpGet("chat/{roomId}")]
    public async Task<IActionResult> CreateMessage([FromRoute] int roomId)
    {
        return View(await _messageService.GetMessagesByRoomId(roomId));
    }

    [Authorize]
    [HttpPost("chat/{roomId}")]
    public async Task<IActionResult> CreateMessage([FromRoute] int roomId, int userId, string text)
    {
        var ident = HttpContext.User.Identity as ClaimsIdentity;
        await _messageService.CreateMessage(int.Parse(ident.Claims.ToArray()[1].Value), roomId, text);
        return View();
    }
}