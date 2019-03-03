using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;

namespace GraphQl.Subscriptions.WebSockets.Apollo.Dtos
{
    [DataContract]
    internal class IncomingMessage : ApolloProtocol
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "payload")]
        public Payload Payload { get; set; }
    }

    internal class Payload
    {
        [DataMember(Name = "query")]
        public string Query { get; set; }

        [DataMember(Name = "variables")]
        public JObject Variables { get; set; }
    }
}
