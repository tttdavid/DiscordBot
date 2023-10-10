using DSharpPlus.Entities;
using DSharpPlus;
using DSharpPlus.SlashCommands;
using System.Diagnostics;

namespace src.SlashCommands
{
    public class TimeCommands : ApplicationCommandModule
    {
        [SlashCommand("Timer", "Sets timer for X seccond")]
        public async Task TimerSlash(InteractionContext ctx, [Option("time", "Seconds to run")] double time)
        {
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
                .WithContent($"Starting"));

            var message = await ctx.GetOriginalResponseAsync();
            while (time > 0)
            {
                await message.ModifyAsync(i => i.Content = time.ToString());
                Thread.Sleep(665);
                time--;
            }
            await message.ModifyAsync(i => i.Content = $"{time} | {ctx.Member.Mention}, Time expired");
        }
    }
}