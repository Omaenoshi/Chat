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

    public IEnumerable<Message> GetMessages(int roomId)
    {
        throw new NotImplementedException();
    }
}