using Cocona;
using CoconaConsoleApp.Commands;
using CoconaConsoleApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;


namespace CoconaConsoleApp;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Log.Logger = SerilogFactory.CreateLogger();
        var builder = CoconaApp.CreateBuilder(args, options =>
        {
            options.TreatPublicMethodsAsCommands = false;
        });
        builder.Services.AddLogging(config =>
        {
            config.ClearProviders();
            config.AddSerilog(Log.Logger, true);
        });
        builder.Host.UseSerilog(Log.Logger, true);
        builder.Configuration.AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json"));
        // Add Services
        var app = builder.Build();
        app.AddCommands<ExampleCommands>();
        // Run the app
        await app.RunAsync();
    }
}
