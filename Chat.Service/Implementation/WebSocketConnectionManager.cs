using System.Collections.Concurrent;
using System.Net.WebSockets;

namespace Chat.Service.Implementation
{
    public class WebSocketConnectionManager
    {
        private readonly ConcurrentDictionary<int, List<WebSocket>> _sockets = new ConcurrentDictionary<int, List<WebSocket>>();

        public void AddWebSocket(int key, WebSocket socket)
        {
            if (!_sockets.ContainsKey(key))
            {
                _sockets.TryAdd(key, new List<WebSocket>());
            }

            if (!_sockets[key].Contains(socket))
                _sockets[key].Add(socket);
        }

        public void RemoveWebSocket(int key, WebSocket socket)
        {
            if (_sockets.ContainsKey(key))
            {
                _sockets[key].Remove(socket);

                if (_sockets[key].Count == 0)
                {
                    _sockets.TryRemove(key, out _);
                }
            }
        }

        public List<WebSocket> GetAllSocketsByKey(int key)
        {
            if (_sockets.ContainsKey(key))
            {
                return _sockets[key];
            }

            return null;
        }
    }
}