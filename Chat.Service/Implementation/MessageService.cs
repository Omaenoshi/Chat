using Chat.Database.Interface;
using Chat.Domain.Entity;
using Chat.Service.Interface;

namespace Chat.Service.Implementation;

public class MessageService : IMessageService
{
    private readonly IMessageRepository _messageRepository;

    public MessageService(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task<IEnumerable<Message>> GetMessagesByRoomId(int id)
    {
        return await _messageRepository.GetByRoomId(id);
    }

    public async Task<int> CreateMessage(Message message)
    {
        return await _messageRepository.Create(message);
    }
    
    public async Task<int> DeleteMessageById(int id)
    {
        return await _messageRepository.DeleteById(id);
    }
}