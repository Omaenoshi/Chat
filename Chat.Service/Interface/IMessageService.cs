using Chat.Domain;

namespace Chat.Service.Interface;

public interface IMessageService
{
    Task<IEnumerable<Message>> GetMessagesByRoomId(int id);
    Task<int> CreateMessage(Message message);
    Task<int> CreateMessage(int userId, int roomId, string text);
    Task<int> DeleteMessageById(int id);
}