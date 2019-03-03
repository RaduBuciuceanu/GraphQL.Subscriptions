using System;
using System.Net.WebSockets;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Subscriptions.WebSockets.Middlewares
{
    internal class Subscriptions
    {
        private readonly RequestDelegate _next;

        public Subscriptions(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/graphql" && context.WebSockets.IsWebSocketRequest)
            {
                WebSocket socket = await context.WebSockets.AcceptWebSocketAsync("graphql-ws").ConfigureAwait(false);
                StartCommunication(socket, context.RequestServices);
            }
            else
            {
                await _next(context);
            }
        }

        private static void StartCommunication(WebSocket socket, IServiceProvider provider)
        {
            var schema = provider.GetService<Schema>();
            var shouldReceive = new ShouldReceive(socket);
            var receive = new Receive(socket);
            var send = new Send(socket);
            var communication = new Communicate(schema, shouldReceive, receive, send);
            communication.Execute().ToTask();
        }
    }
}
