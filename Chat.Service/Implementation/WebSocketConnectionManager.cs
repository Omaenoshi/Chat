using System.Collections.Concurrent;
using System.Net.WebSockets;

namespace Chat.Service.Implementation
{
    public class WebSocketConnectionManager
    {
        private readonly ConcurrentDictionary<string, WebSocket> _sockets = new ConcurrentDictionary<string, WebSocket>();

        public void AddSocket(WebSocket socket)
        {
            _sockets.TryAdd(CreateConnectionId(), socket);
        }

        public void RemoveSocket(WebSocket socket)
        {
            var connectionId = GetConnectionId(socket);
            _sockets.TryRemove(connectionId, out _);
        }

        public WebSocket GetSocketById(string connectionId)
        {
            _sockets.TryGetValue(connectionId, out WebSocket socket);
            return socket;
        }

        public ConcurrentDictionary<string, WebSocket> GetAllSockets()
        {
            return _sockets;
        }

        private string GetConnectionId(WebSocket socket)
        {
            foreach (var item in _sockets)
            {
                if (item.Value == socket)
                {
                    return item.Key;
                }
            }

            return string.Empty;
        }

        private string CreateConnectionId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}