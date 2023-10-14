using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace src.Commands
{
    public class FunCommands : BaseCommandModule
    {
        [Command("test")]
        public async Task TestCommand(CommandContext ctx)
        {
            await ctx.Message.RespondAsync("Test");
        }

        [Command("анек")]
        public async Task RandomAnek(CommandContext ctx)
        {
            DiscordChannel channel = ctx.Channel.Guild.GetChannel(809592781135806534);
            var messages = await channel.GetMessagesBeforeAsync(channel.LastMessageId.Value, 1000);
            await ctx.Message.RespondAsync(messages[new Random().Next(messages.Count)].Content);
        }

        [Command("дединсайд")]
        public async Task Deadinside(CommandContext ctx)
        {
            await ctx.Message.RespondAsync("https://media.discordapp.net/attachments/806172074388357142/1118809890434072576/image.png");
        }
    }
}
