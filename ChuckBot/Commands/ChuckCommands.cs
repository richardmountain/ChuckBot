using ChuckBot.Models;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace ChuckBot.Commands;

public class ChuckCommands : ApplicationCommandModule
{
    [SlashCommand("chuck", "Returns a random Chuck Norris joke")]
    public async Task ChuckCommand(InteractionContext ctx)
    {
        await ctx.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);
        
        var chuck = new Chuck();
        var message = await chuck.GetRandomAsync();
        var builder = new DiscordEmbedBuilder();
        builder.Author = new DiscordEmbedBuilder.EmbedAuthor() { Name = "Chuck Bot", Url = "" };
        builder.Description = message.Value;

        await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(builder.Build()));
    }
}