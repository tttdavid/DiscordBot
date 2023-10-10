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
            await ctx.RespondAsync("qwe");
        }

        [Command("дединсайд")]
        public async Task Deadinside(CommandContext ctx)
        {
            await ctx.Message.RespondAsync("https://media.discordapp.net/attachments/806172074388357142/1118809890434072576/image.png");
        }
    }
}
