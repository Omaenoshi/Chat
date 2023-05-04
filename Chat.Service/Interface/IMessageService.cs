using Chat.Database.Interface;
using Chat.Domain.Entity;

namespace Chat.Service.Interface;

public interface IMessageService
{
    IEnumerable<Message> GetMessages(int roomId);
    
}