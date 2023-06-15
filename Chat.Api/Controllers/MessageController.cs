using System.Net.WebSockets;
using System.Security.Claims;
using Chat.Service.Implementation;
using Chat.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Chat.Api.Controllers;

[Authorize]
[Route("/api/messages")]
public class MessageController : Controller
{
    private readonly IMessageService _messageService;
    private readonly WebSocketHandler _webSocketHandler;

    public MessageController(IMessageService messageService, WebSocketHandler webSocketHandler)
    {
        _messageService = messageService;
        _webSocketHandler = webSocketHandler;
    }

    [Authorize]
    [HttpGet("chat/{roomId}")]
    public async Task<IActionResult> CreateMessage([FromRoute] int roomId)
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            var socket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            var ident = HttpContext.User.Identity as ClaimsIdentity;
            var username = ident.Name;
            await _webSocketHandler.OnConnectedAsync(socket, int.Parse(ident.Claims.ToArray()[1].Value), roomId, username);
        }
        else
        {
            HttpContext.Response.StatusCode = 400;
        }
        return View(await _messageService.GetMessagesByRoomId(roomId));
    }
}