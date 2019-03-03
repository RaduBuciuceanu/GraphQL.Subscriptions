using System;
using System.Net.WebSockets;
using System.Reactive.Linq;
using GraphQl.Subscriptions.Core;

namespace GraphQL.Subscriptions.WebSockets
{
    internal class ShouldReceive : IShouldReceive
    {
        private readonly WebSocket _socket;

        public ShouldReceive(WebSocket socket)
        {
            _socket = socket;
        }

        public IObservable<bool> Execute()
        {
            return Observable.Return(!_socket.CloseStatus.HasValue);
        }
    }
}
