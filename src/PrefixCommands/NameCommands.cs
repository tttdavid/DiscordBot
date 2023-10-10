using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace src.Commands
{
    public class NameCommands : BaseCommandModule
    {
        [Command("rofl")]
        public async Task Zaroflit(CommandContext ctx)
        {
            DiscordMember user = await ctx.Channel.Guild.GetMemberAsync(437600881458937859);
            string name = "Кабанчик";
            await user.ModifyAsync(x => x.Nickname = name);
        }

        [Command("editbotname")]
        [RequireRoles(RoleCheckMode.MatchIds, 1157368470351126568)]
        public async Task ChangeBotName(CommandContext ctx, string xdd)
        {
            DiscordMember user = await ctx.Channel.Guild.GetMemberAsync(1130753536574103562);
            await user.ModifyAsync(x => x.Nickname = xdd);
        }

        [Command("editname")]
        [RequireRoles(RoleCheckMode.MatchIds, 1157368470351126568)]
        public async Task EditUsername(CommandContext ctx, DiscordMember member, string msg) => await member.ModifyAsync(x => x.Nickname = msg);
    }
}