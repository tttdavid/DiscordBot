using System;
using System.Reflection;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using src.TempClasses;

namespace src.Commands
{
    public class TempCommands : BaseCommandModule
    {
        [Command("temp")]
        public async Task TempByCity(CommandContext ctx, string s)
        {
            if (ctx.Message.Author.IsBot)
                return;

            WeatherObj response = await Temp.Weather(s);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder()
            {
                Color = DiscordColor.Magenta,
                Title = $"Weather in {Capitalize(s)}",
                Description =
                $"Weather: {response.Status}\n" +
                $"Temperature: {response.Temp}°C\n" +
                $"Feels like: {response.Feels}°C",
            };
            embed.WithThumbnail($"https:{response.Icon}");

            await ctx.Message.RespondAsync(embed);
        }

        private async Task ErrorMessage(CommandContext ctx, string errorMessage)
        {
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder()
            {
                Color = DiscordColor.Magenta,
                Title = errorMessage,
            };
            await ctx.Message.RespondAsync(embed);
        }

        private string Capitalize(string str)
        {
            str = str.ToLower();
            char[] arr = str.ToCharArray();
            arr[0] = char.ToUpper(arr[0]);
            return new string(arr);
        }
    }
}
