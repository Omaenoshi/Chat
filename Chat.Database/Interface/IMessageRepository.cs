using Chat.Domain.Entity;

namespace Chat.Database.Interface;

public interface IMessageRepository : IBaseRepository<Message>
{
    Task<IEnumerable<Message>> GetByRoomId(int id);
}