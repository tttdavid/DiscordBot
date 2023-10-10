using System;
using DSharpPlus;
using DSharpPlus.Entities;
using src.Soda;
using System.Reflection;

namespace src
{
    public partial class Bot
    {
        public void RunNonPrefixCommands()
        {
            // ник дединсайда
            // client.MessageCreated += async (client, msg) =>
            // {
            //     if (msg.Author.Id != 437600881458937859 || msg.Channel.Guild is null)
            //         return;

            //     DiscordMember user = await msg.Channel.Guild.GetMemberAsync(437600881458937859);
            //     await user.ModifyAsync(u => u.Nickname = msg.Author.Username);
            // };


            // Кiт
            Client.MessageCreated += async (client, ctx) =>
            {
                if (ctx.Message.Content.Contains("Кiт"))
                {
                    await ctx.Message.RespondAsync("https://media.giphy.com/media/KBz11o4GydjrtHobrD/giphy-downsized-large.gif");
                }
            };


            // Ai
            Client.MessageCreated += async (client, ctx) =>
            {
                if (ctx.Message.Author.IsBot || !ctx.Message.Content.StartsWith("<@1130753536574103562>"))
                    return;

                var message = ctx.Message;
                string prompt = message.Content[23..];

                await message.CreateReactionAsync(DiscordEmoji.FromUnicode(client, "🟢"));
                string result = await Xdd.GetResponse(prompt);

                if (result == "Failed")
                {
                    await message.CreateReactionAsync(DiscordEmoji.FromUnicode(client, "🔴"));
                    await Task.Delay(300);
                    await message.DeleteReactionsEmojiAsync(DiscordEmoji.FromUnicode(client, "🟢"));
                    await Task.Delay(300);
                    await message.RespondAsync("Error");

                    return;
                }

                await message.RespondAsync(result);
                await Task.Delay(300);
                await message.CreateReactionAsync(DiscordEmoji.FromUnicode(client, "✅"));
                await Task.Delay(300);
                await message.DeleteReactionsEmojiAsync(DiscordEmoji.FromUnicode(client, "🟢"));
            };

            // 8 ball
            // Client.MessageCreated += async (client, msg) =>
            // {
            //     if (msg.Author.IsBot)
            //         return;

            //     if (msg.Message.Content.StartsWith("<@1130753536574103562>") && msg.Message.Content.EndsWith("?"))
            //     {
            //         Random rnd3 = new Random();
            //         string reply = string.Empty;
            //         switch (rnd3.Next(0, 9))
            //         {
            //             case 1:
            //                 reply = "Бесспорно";
            //                 break;
            //             case 2:
            //                 reply = "Можешь быть уверен в этом";
            //                 break;
            //             case 3:
            //                 reply = "Вероятнее всего";
            //                 break;
            //             case 4:
            //                 reply = "Да";
            //                 break;
            //             case 5:
            //                 reply = "Спроси позже";
            //                 break;
            //             case 6:
            //                 reply = "Сейчас нельзя предсказать";
            //                 break;
            //             case 7:
            //                 reply = "Даже не думай";
            //                 break;
            //             case 8:
            //                 reply = "нет";
            //                 break;
            //         }
            //         await msg.Message.RespondAsync(reply);
            //     }
            // };
        }
    }
}
