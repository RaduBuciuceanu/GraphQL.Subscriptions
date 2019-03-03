# GraphQl.Subscriptions

## Usage
```c#
using GraphQl.Subscriptions.WebSockets.Apollo.Extensions;
Or
using GraphQl.Subscriptions.WebSockets.Extensions;

public class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
    }

    public static void Configure(IApplicationBuilder builder)
    {
        ...
        builder.UseWebSockets();
        builder.UseSubscriptions();
        ...
    }
}  
```
