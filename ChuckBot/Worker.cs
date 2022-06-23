using ChuckBot.Commands;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.SlashCommands;

namespace ChuckBot;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly DiscordClient _discordClient;
    private SlashCommandsExtension _commands;
    private ulong _testGuildId;

    public Worker(ILogger<Worker> logger, DiscordClient discordClient, IConfiguration configuration)
    {
        _logger = logger;
        _discordClient = discordClient;
        _testGuildId = ulong.Parse(configuration["Discord:TestGuildId"]);
        
        _commands = _discordClient.UseSlashCommands();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _commands.RegisterCommands<ChuckCommands>(_testGuildId);

        await _discordClient.ConnectAsync();

        await Task.Delay(-1, stoppingToken);
    }
}