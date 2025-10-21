using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectEuler.EulerSolutions;

namespace ProjectEuler;

public static class Program
{
    public static void Main(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();
        using IServiceScope scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var app = services.GetRequiredService<App>();
        app.Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        return Host
            .CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                var eulerTypes = assembly.GetTypes().Where(t => typeof(IEulerSolution).IsAssignableFrom(t) && t is { IsClass: true, IsAbstract: false });
                foreach (var type in eulerTypes)
                {
                    services.AddTransient(typeof(IEulerSolution), type);
                }
                
                services.AddTransient<App>();
            });
    }
}