using Chat.Database;
using Chat.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers;


[Route("/api/messages")]
public class MessageController : Controller
{
    //private readonly IMessageService _messageService;

    //public MessageController(IMessageService messageService)
    //{
    //    _messageService = messageService;
    //}
    private readonly ChatDbContext _context;

    public MessageController(ChatDbContext context)
    {
        _context = context;
    }

    [HttpGet("chat/{roomId}")]
    public IActionResult CreateMessage([FromRoute] int roomId)
    {
        return View(roomId);
    }

    [HttpPost("chat/{roomId}")]
    public async Task<IActionResult> CreateMessage([FromRoute] int roomId, string text, int userId = 1)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == userId);
        var room = _context.Rooms.FirstOrDefault(x => x.Id == roomId);
        var message = new Message { Room = room, Text = text, User = user };
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
        return View();
    }

    //[HttpGet("/rooms/{id}")]
    //public async Task<IEnumerable<Message>> GetByRoomId(int id)
    //{
    //    return await _messageService.GetMessagesByRoomId(id);
    //}

    //[HttpPost]
    //public async Task<int> Create(Message message)
    //{
    //    return await _messageService.CreateMessage(message);
    //}

    //[HttpDelete("{id}")]
    //public async Task<int> Delete(int id)
    //{
    //    return await _messageService.DeleteMessageById(id);
    //}
}