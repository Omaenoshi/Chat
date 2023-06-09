﻿using Chat.Database.Interface;
using Chat.Domain;
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

    public async Task<int> CreateMessage(int userId, int roomId, string text)
    {
        return await _messageRepository.Create(userId, roomId, text);
    }

    public async Task<int> DeleteMessageById(int id)
    {
        return await _messageRepository.DeleteById(id);
    }

    public async Task<int> Create(int userId, int roomId, string text)
    {
        return await _messageRepository.Create(userId, roomId, text);
    }
}