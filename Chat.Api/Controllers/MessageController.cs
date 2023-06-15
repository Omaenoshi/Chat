using System.Security.Claims;
using Chat.Service.Implementation;
using Chat.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers;

[Authorize]
[Route("/api/messages")]
public class MessageController : Controller
{
    private readonly IMessageService _messageService;
    private readonly WebSocketHandler _webSocketHandler;
    private readonly WebSocketConnectionManager _webSocketConnectionManager;

    public MessageController(IMessageService messageService, WebSocketHandler webSocketHandler, WebSocketConnectionManager webSocketConnectionManager)
    {
        _messageService = messageService;
        _webSocketHandler = webSocketHandler;
        _webSocketConnectionManager = webSocketConnectionManager;
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
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            var socket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            await _webSocketHandler.OnConnectedAsync(socket);
        }
        else
        {
            HttpContext.Response.StatusCode = 400;
        }
        var ident = HttpContext.User.Identity as ClaimsIdentity;
        await _messageService.CreateMessage(int.Parse(ident.Claims.ToArray()[1].Value), roomId, text);
        return View(await _messageService.GetMessagesByRoomId(roomId));
    }
}