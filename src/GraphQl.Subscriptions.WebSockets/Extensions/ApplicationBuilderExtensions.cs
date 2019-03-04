using Microsoft.AspNetCore.Builder;
using SubscriptionsMiddleware = GraphQL.Subscriptions.WebSockets.Middlewares.Subscriptions;

namespace GraphQL.Subscriptions.WebSockets.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseWebSocketsSubscriptions(this IApplicationBuilder instance,
            string path = "/graphql",
            string protocol = "graphql-ws")
        {
            return instance.UseMiddleware<SubscriptionsMiddleware>(path, protocol);
        }
    }
}
