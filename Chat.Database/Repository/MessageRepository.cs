using Chat.Database.Interface;
using Chat.Domain.Entity;

namespace Chat.Database.Repository;

public class MessageRepository : IMessageRepository
{
    public bool Create(Message entity)
    {
        throw new NotImplementedException();
    }

    public Message GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Message> GetAll()
    {
        throw new NotImplementedException();
    }

    public bool Delete(Message entity)
    {
        throw new NotImplementedException();
    }
}