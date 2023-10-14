using System;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace src.Commands
{
    public class InfoCommands : BaseCommandModule
    {
        [Command("avatar")]
        public async Task GetAvatar(CommandContext ctx)
        {
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder
            {
                Color = DiscordColor.SpringGreen,
                ImageUrl = ctx.Member.AvatarUrl,
                Title = $"{ctx.Member.GlobalName}'s Profile pic."
            };
            await ctx.Message.RespondAsync(embed);
        }

        [Command("avatar")]
        public async Task GetAvatar(CommandContext ctx, DiscordMember member)
        {
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Magenta,
                ImageUrl = member.AvatarUrl,
                Title = $"{member.DisplayName}'s Profile pic."
            };
            await ctx.Message.RespondAsync(embed);
        }

        [Command("regdate")]
        public async Task RegDate(CommandContext ctx)
        {
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Magenta,
                Title = $"{ctx.Member.GlobalName} joined discord at {ctx.Member.CreationTimestamp.ToString("yyyy-MM-dd")} " +
                        $"{ctx.Member.CreationTimestamp.Hour}:{ctx.Member.CreationTimestamp.Minute} \n" +
                        $"{(int)(DateTimeOffset.Now - ctx.Member.CreationTimestamp).TotalDays} Days on dicord",
                ImageUrl = ctx.Member.AvatarUrl
            };
            await ctx.Message.RespondAsync(embed);
        }

        [Command("regdate")]
        public async Task RegDate(CommandContext ctx, DiscordMember member)
        {
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Magenta,
                Title = $"{member.DisplayName} joined discord at {member.CreationTimestamp.ToString("yyyy-MM-dd")}" +
                        $"{member.CreationTimestamp.ToString("hh:mm:tt")} \n" +
                        $"{(int)(DateTimeOffset.Now - member.CreationTimestamp).TotalDays} Days on dicord",
                ImageUrl = member.AvatarUrl
            };
            await ctx.Message.RespondAsync(embed);
        }
    }
}
