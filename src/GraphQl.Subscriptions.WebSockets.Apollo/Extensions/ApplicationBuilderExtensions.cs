using Microsoft.AspNetCore.Builder;
using SubscriptionsMiddleware = GraphQl.Subscriptions.WebSockets.Apollo.Middlewares.Subscriptions;

namespace GraphQl.Subscriptions.WebSockets.Apollo.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseGraphQLSubscriptions(this IApplicationBuilder instance,
            string path = "/graphql",
            string protocol = "graphql-ws")
        {
            return instance.UseMiddleware<SubscriptionsMiddleware>(path, protocol);
        }
    }
}
