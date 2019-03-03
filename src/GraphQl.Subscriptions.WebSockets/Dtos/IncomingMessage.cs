using Newtonsoft.Json.Linq;

namespace GraphQL.Subscriptions.WebSockets.Dtos
{
    internal class IncomingMessage
    {
        public string Query { get; set; }

        public JObject Variables { get; set; }
    }
}
