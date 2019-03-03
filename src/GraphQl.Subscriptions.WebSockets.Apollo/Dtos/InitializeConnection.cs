using System.Runtime.Serialization;

namespace GraphQl.Subscriptions.WebSockets.Apollo.Dtos
{
    [DataContract]
    internal class InitializeConnection : ApolloProtocol
    {
        public InitializeConnection()
        {
            Type = InitializeConnection;
        }
    }
}
