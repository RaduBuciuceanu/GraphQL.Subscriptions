using System.Runtime.Serialization;

namespace GraphQl.Subscriptions.WebSockets.Apollo.Dtos
{
    [DataContract]
    internal class OutgoingMessage : ApolloProtocol
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "payload")]
        public object Payload { get; set; }

        public OutgoingMessage()
        {
            Type = SendingData;
        }
    }
}
