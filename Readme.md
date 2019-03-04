# GraphQl.Subscriptions
Base implementation of GraphQL subscriptions using web sockets. It also supports [Apollo](https://www.apollographql.com/) communication protocol. Tested with [graphql-playground](https://github.com/prisma/graphql-playground).

## Usage
```c#
...
using GraphQl.Subscriptions.WebSockets.Apollo.Extensions; or using GraphQl.Subscriptions.WebSockets.Extensions;
...

public class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
    }

    public static void Configure(IApplicationBuilder builder)
    {
        ...
        builder.UseWebSockets();
        builder.UseApolloSubscriptions(); or builder.UseWebSocketsSubscriptions();
        ...
    }
}  
```

Don't forget to enable CORS. In most cases you need it for communication between your client and your server.
