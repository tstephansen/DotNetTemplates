using Serilog.Exceptions.Core;
using Serilog;
using Serilog.Exceptions;

namespace CoconaConsoleApp.Services;

internal static class SerilogFactory
{
    public static Serilog.ILogger CreateLogger()
    {
        var logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .Enrich.WithThreadId()
            .Enrich.WithExceptionDetails(new DestructuringOptionsBuilder()
                .WithDefaultDestructurers())
            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}{NewLine}{Properties}")
            .WriteTo.Debug(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}{NewLine}{Properties}")
            .CreateLogger();
        return logger;
    }
}