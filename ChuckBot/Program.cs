using ChuckBot;
using DSharpPlus;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration configuration = hostContext.Configuration;
        
        services.AddHostedService<Worker>();
        services.AddSingleton(new DiscordClient(new DiscordConfiguration()
            { Token = configuration["Discord:Token"], TokenType = TokenType.Bot }));
        services.AddSingleton(configuration);
    })
    .Build();

await host.RunAsync();