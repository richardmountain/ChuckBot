using ChuckBot.Commands;
using DSharpPlus;
using DSharpPlus.SlashCommands;

namespace ChuckBot;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly DiscordClient _discordClient;

    public Worker(ILogger<Worker> logger, DiscordClient discordClient)
    {
        _logger = logger;
        _discordClient = discordClient;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var commands = _discordClient.UseSlashCommands();

        commands.RegisterCommands<ChuckCommand>();
        
        await _discordClient.ConnectAsync();
        await Task.Delay(-1, stoppingToken);
        // while (!stoppingToken.IsCancellationRequested)
        // {
        //     _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        //     await Task.Delay(1000, stoppingToken);
        // }
    }
}