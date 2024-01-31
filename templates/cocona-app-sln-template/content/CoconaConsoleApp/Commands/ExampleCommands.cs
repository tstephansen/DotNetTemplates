using Cocona;
using Microsoft.Extensions.Logging;


namespace CoconaConsoleApp.Commands;

public class ExampleCommands(ILogger<ExampleCommands> Logger)
{
    [Command("CommandName", Description = "Command Description")]
    public async Task ExampleCommand([Option('o', Description = "An example option")] bool useExampleOption = false)
    {
        if (!useExampleOption)
            Console.WriteLine("Running example command");
        else
            Console.WriteLine("Running example command using example option");
        await Task.Delay(100);
        Console.WriteLine("Command finished");
        Logger.LogInformation("Command complete");
    }
}