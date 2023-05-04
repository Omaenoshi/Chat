using Chat.Domain;
using Chat.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers;


[Route("/api/messages")]
public class MessageController : Controller
{
    private readonly IMessageService _messageService;

    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }
    [HttpGet("/rooms/{id}")]
    public async Task<IEnumerable<Message>> GetByRoomId(int id)
    {
        return await _messageService.GetMessagesByRoomId(id);
    }

    [HttpPost]
    public async Task<int> Create(Message message)
    {
        return await _messageService.CreateMessage(message);
    }

    [HttpDelete("{id}")]
    public async Task<int> Delete(int id)
    {
        return await _messageService.DeleteMessageById(id);
    }
}