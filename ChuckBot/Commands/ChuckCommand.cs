using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace ChuckBot.Commands;

public class ChuckCommand : ApplicationCommandModule
{
    [SlashCommand("chuck", "Returns a random Chuck Norris joke")]
    public async Task Chuck(InteractionContext ctx)
    {
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
            new DiscordInteractionResponseBuilder().WithContent("Success!"));
    }
}