using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.Implementation
{
    public class WebSocketHandler
    {
        private readonly WebSocketConnectionManager _connectionManager;

        public WebSocketHandler(WebSocketConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public async Task OnConnectedAsync(WebSocket socket)
        {
            _connectionManager.AddSocket(socket);

            while (socket.State == WebSocketState.Open)
            {
                var buffer = new byte[1024 * 4];
                var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                var message = System.Text.Encoding.UTF8.GetString(buffer, 0, result.Count);

                await SendMessageAsync(socket, message);
            }

            _connectionManager.RemoveSocket(socket);
        }

        private async Task SendMessageAsync(WebSocket socket, string message)
        {
            var buffer = System.Text.Encoding.UTF8.GetBytes(message);
            await socket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}
