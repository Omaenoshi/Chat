using Chat.Database.Interface;
using Chat.Domain;

namespace Chat.Service.Interface;

public interface IMessageService
{
    Task<IEnumerable<Message>> GetMessagesByRoomId(int id);
    Task<int> CreateMessage(Message message);
    Task<int> DeleteMessageById(int id);
}