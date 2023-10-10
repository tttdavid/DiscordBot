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
        public async Task GetAvatar(CommandContext ctx, string s)
        {
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Magenta,
                ImageUrl = ctx.Message.MentionedUsers.First().AvatarUrl,
                Title = $"{ctx.Message.MentionedUsers.First().GlobalName}'s Profile pic."
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
                        $"{ctx.Member.CreationTimestamp.Hour}:{ctx.Member.CreationTimestamp.Minute}",
                ImageUrl = ctx.Member.AvatarUrl
            };
            await ctx.Message.RespondAsync(embed);
        }

        [Command("regdate")]
        public async Task RegDate(CommandContext ctx, string s)
        {
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Magenta,
                Title = $"{ctx.Message.MentionedUsers.First().GlobalName} joined discord at {ctx.Message.MentionedUsers.First().CreationTimestamp.ToString("yyyy-MM-dd")} " +
                        $"{ctx.Message.MentionedUsers.First().CreationTimestamp.ToString("hh:mm tt")}",
                ImageUrl = ctx.Message.MentionedUsers.First().AvatarUrl
            };
            await ctx.Message.RespondAsync(embed);
        }
    }
}
