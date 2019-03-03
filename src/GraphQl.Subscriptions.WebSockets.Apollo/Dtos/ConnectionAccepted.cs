using System.Runtime.Serialization;

namespace GraphQl.Subscriptions.WebSockets.Apollo.Dtos
{
    [DataContract]
    internal class ConnectionAccepted : ApolloProtocol
    {
        public ConnectionAccepted()
        {
            Type = ConnectionAccepted;
        }
    }
}
