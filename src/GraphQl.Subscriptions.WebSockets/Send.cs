using System;
using System.Net.WebSockets;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using GraphQl.Subscriptions.Core;
using Newtonsoft.Json;

namespace GraphQL.Subscriptions.WebSockets
{
    public class Send : ISend
    {
        private readonly WebSocket _socket;

        public Send(WebSocket socket)
        {
            _socket = socket;
        }

        public IObservable<Unit> Execute(object message)
        {
            return Observable.Return(JsonConvert.SerializeObject(message))
                .Select(a => Encoding.UTF8.GetBytes(a))
                .Do(SendAsync)
                .Select(_ => Unit.Default);
        }

        private void SendAsync(byte[] bytes)
        {
            _socket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None)
                .GetAwaiter().GetResult();
        }
    }
}
