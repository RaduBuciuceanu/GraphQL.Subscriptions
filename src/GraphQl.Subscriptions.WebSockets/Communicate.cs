using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using GraphQl.Subscriptions.Core;
using GraphQL.Subscription;
using GraphQL.Subscriptions.WebSockets.Dtos;
using GraphQL.Types;

namespace GraphQL.Subscriptions.WebSockets
{
    internal class Communicate
    {
        private readonly Schema _schema;
        private readonly IShouldReceive _shouldReceive;
        private readonly IReceive _receive;
        private readonly ISend _send;

        public Communicate(Schema schema, IShouldReceive shouldReceive, IReceive receive, ISend send)
        {
            _schema = schema;
            _shouldReceive = shouldReceive;
            _receive = receive;
            _send = send;
        }

        public IObservable<Unit> Execute()
        {
            return Observable.Return(Unit.Default).Do(_ => StartCommunication());
        }

        private void StartCommunication()
        {
            while (_shouldReceive.Execute().Wait())
            {
                CommunicateOnce();
            }
        }

        private void CommunicateOnce()
        {
            var message = _receive.Execute<IncomingMessage>().Wait();
            SubscriptionExecutionResult result = Execute(message);
            result.Streams.Single().Value.Subscribe(Subscribe);
        }

        private SubscriptionExecutionResult Execute(IncomingMessage message)
        {
            return (SubscriptionExecutionResult)new DocumentExecuter().ExecuteAsync(options =>
            {
                options.Schema = _schema;
                options.Query = message.Query;
                options.Inputs = message.Variables.ToInputs();
            }).GetAwaiter().GetResult();
        }

        private void Subscribe(ExecutionResult executionResult)
        {
            _send.Execute(executionResult).Wait();
        }
    }
}
