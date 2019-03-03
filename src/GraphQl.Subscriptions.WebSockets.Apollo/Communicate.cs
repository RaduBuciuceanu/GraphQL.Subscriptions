using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using GraphQl.Subscriptions.Core;
using GraphQl.Subscriptions.WebSockets.Apollo.Dtos;
using GraphQL;
using GraphQL.Subscription;
using GraphQL.Types;

namespace GraphQl.Subscriptions.WebSockets.Apollo
{
    internal class Communicate
    {
        private readonly Schema _schema;
        private readonly IShouldReceive _shouldReceive;
        private readonly IReceive _receive;
        private readonly ISend _send;

        private string _id;

        public Communicate(Schema schema, IShouldReceive shouldReceive, IReceive receive, ISend send)
        {
            _schema = schema;
            _shouldReceive = shouldReceive;
            _receive = receive;
            _send = send;
        }

        public IObservable<Unit> Execute()
        {
            return Observable.Return(Unit.Default)
                .Do(_ => InitializeCommunication())
                .Do(_ => StartCommunication());
        }

        private void InitializeCommunication()
        {
            _receive.Execute<InitializeConnection>().Wait();
            _send.Execute(new ConnectionAccepted()).ToTask();
            _send.Execute(new KeepConnectionAlive()).ToTask();
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
            _id = message.Id;

            SubscriptionExecutionResult result = Execute(message);
            result.Streams.Single().Value.Subscribe(Subscribe);
        }

        private SubscriptionExecutionResult Execute(IncomingMessage message)
        {
            return (SubscriptionExecutionResult)new DocumentExecuter().ExecuteAsync(options =>
            {
                options.Schema = _schema;
                options.Query = message.Payload.Query;
                options.Inputs = message.Payload.Variables.ToInputs();
            }).GetAwaiter().GetResult();
        }

        private void Subscribe(ExecutionResult executionResult)
        {
            _send.Execute(new OutgoingMessage { Id = _id, Payload = executionResult }).Wait();
            _send.Execute(new KeepConnectionAlive()).Wait();
        }
    }
}
