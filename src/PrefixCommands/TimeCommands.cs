using System;
using src.TempClasses;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;


namespace src.Commands
{
    public class TimeCommands : BaseCommandModule
    {
        // [Command("timer")]
        // public async Task Timer(CommandContext ctx, int a)
        // {

        //     DiscordEmbedBuilder embed = new DiscordEmbedBuilder()
        //     {
        //         Color = DiscordColor.Magenta,
        //         Title = $"Embed",
        //     };

        //     DiscordMessageBuilder zxc = new DiscordMessageBuilder()
        //     {
        //         Embed = embed
        //     };

        //     DiscordMessage msg = new DiscordMessage(zxc);

        //     await Task.Delay(a * 1000);
        //     await ctx.Channel.SendMessageAsync($"{ctx.Member.Mention} {a} second(s) expired");
        // }

        [Command("time")]
        public async Task TimeIn(CommandContext ctx)
        {
            DateTime prague = await Temp.Time("prague");
            DateTime moscow = await Temp.Time("moscow");
            DateTime tbilisi = await Temp.Time("tbilisi");
            DateTime vladivostok = await Temp.Time("vladivostok");

            DiscordEmbedBuilder embed = new DiscordEmbedBuilder()
            {
                Color = DiscordColor.Magenta,
                Title = $"Time in :",
                Description =
                $"Prague: {prague.ToShortTimeString()}\n" +
                $"Moscow: {moscow.ToShortTimeString()}\n" +
                $"Tbilisi: {tbilisi.ToShortTimeString()}\n" +
                $"Vladivostok: {vladivostok.ToShortTimeString()}\n",
            };

            await ctx.Message.RespondAsync(embed);
        }
    }
}
