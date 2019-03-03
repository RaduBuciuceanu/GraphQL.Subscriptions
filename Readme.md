# GraphQl.Subscriptions

## Usage
```c#
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
