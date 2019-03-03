using System.Runtime.Serialization;

namespace GraphQl.Subscriptions.WebSockets.Apollo.Dtos
{
    [DataContract]
    internal class KeepConnectionAlive : ApolloProtocol
    {
        public KeepConnectionAlive()
        {
            Type = KeepConnectionAlive;
        }
    }
}
