using Chat.Domain;
using Chat.Service.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Chat.Service.Implementation
{
    public class WebSocketHandler
    {
        private readonly WebSocketConnectionManager _connectionManager;
        private readonly IMessageService _messageService;

        public WebSocketHandler(WebSocketConnectionManager connectionManager, IMessageService messageService)
        {
            _connectionManager = connectionManager;
            _messageService = messageService;
        }

        public async Task OnConnectedAsync(WebSocket socket, int userId, int roomId, string username)
        {
            _connectionManager.AddSocket(socket);

            while (socket.State == WebSocketState.Open)
            {
                var buffer = new byte[1024 * 4];
                var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                var message = System.Text.Encoding.UTF8.GetString(buffer, 0, result.Count);

                if (!message.Equals(""))
                    await _messageService.CreateMessage(userId, roomId, message);

                var data = new
                {
                    username,
                    message
                };

                var json = JsonSerializer.Serialize(data);

                await SendMessageAsync(socket, json);
            }

            _connectionManager.RemoveSocket(socket);
        }

        public async Task SendMessageAsync(WebSocket socket, string message)
        {
            var buffer = System.Text.Encoding.UTF8.GetBytes(message);
            await socket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}
