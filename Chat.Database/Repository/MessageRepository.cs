using Chat.Database.Interface;
using Chat.Domain.Entity;

namespace Chat.Database.Repository;

public class MessageRepository : IMessageRepository
{
    public async Task<int> Create(Message entity)
    {
        throw new NotImplementedException();
    }

    public async Task<Message> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Message>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}