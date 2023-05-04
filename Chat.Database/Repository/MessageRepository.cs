using Chat.Database.Interface;
using Chat.Domain.Entity;

namespace Chat.Database.Repository;

public class MessageRepository : IMessageRepository
{
    public Task<int> Create(Message entity)
    {
        throw new NotImplementedException();
    }

    public Task<Message> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Message>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<int> Delete(Message entity)
    {
        throw new NotImplementedException();
    }
}