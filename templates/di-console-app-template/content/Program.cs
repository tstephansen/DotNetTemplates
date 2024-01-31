using DIConsoleApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;


namespace DIConsoleApp;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Log.Logger = SerilogFactory.CreateLogger();
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddLogging(config =>
        {
            config.ClearProviders();
            config.AddSerilog(Log.Logger, true);
        });
        builder.Configuration.AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json"));
        // Add Services Here
        var host = builder.Build();
        // Resolve Services Here
        
        // Do Work Here
        
    }
}