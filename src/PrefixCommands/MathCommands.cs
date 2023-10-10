using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;


namespace src.Commands
{
    public class MathCommands : BaseCommandModule
    {
        [Command("calc")]
        public async Task Calc(CommandContext ctx, double a, string command, double b)
        {
            double result = 0;
            switch (command)
            {
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "/":
                    result = a / b;
                    break;
            }

            DiscordEmbedBuilder embed = new DiscordEmbedBuilder()
            {
                Color = DiscordColor.Magenta,
                Title = $"{a} {command} {b} = {result}"
            };
            await ctx.Message.RespondAsync(embed);
        }

        [Command("random")]
        public async Task Random(CommandContext ctx, int a, int b)
        {
            Random rnd = new Random();
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Magenta,
                Title = $"Random number between {a} and {b} is {rnd.Next(a, b)}"
            };
            await ctx.Message.RespondAsync(embed);
        }
    }
}
