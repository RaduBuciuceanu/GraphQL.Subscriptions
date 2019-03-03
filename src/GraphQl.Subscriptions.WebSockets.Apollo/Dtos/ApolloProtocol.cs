using System.Runtime.Serialization;

namespace GraphQl.Subscriptions.WebSockets.Apollo.Dtos
{
    [DataContract]
    internal abstract class ApolloProtocol
    {
        public const string InitializeConnection = "connection_init";
        public const string ConnectionAccepted = "connection_ack";
        public const string KeepConnectionAlive = "ka";
        public const string SendingData = "data";
        public const string Complete = "complete";

        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}
