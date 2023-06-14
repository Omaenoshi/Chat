using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Chat.Service.Interface;
using Microsoft.AspNetCore.Authorization;

namespace Chat.Api.Controllers;


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
    public IActionResult CreateMessage([FromRoute] int roomId)
    {
        

        return View();
    }
    [Authorize]
    [HttpPost("chat/{roomId}")]
    public async Task<IActionResult> CreateMessage([FromRoute] int roomId, int userId, string text)
    {
        ClaimsIdentity ident = HttpContext.User.Identity as ClaimsIdentity;
        await _messageService.CreateMessage(int.Parse(ident.Claims.ToArray()[1].Value), roomId, text);
        return View();
    }
}