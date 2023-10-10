using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.SlashCommands;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;


namespace src
{
    public partial class Bot
    {
        public DiscordClient Client { get; private set; }
        public InteractivityExtension Interactivity { get; private set; }
        public CommandsNextExtension PrefixCommands { get; private set; }
        public SlashCommandsExtension SlashCommands { get; private set; }

        public async Task RunAsync()
        {
            var config = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = Pepsi.Get("token"),
                TokenType = TokenType.Bot,
                AutoReconnect = true
            };

            Client = new DiscordClient(config);

            Client.UseInteractivity(new InteractivityConfiguration()
            {
                Timeout = TimeSpan.FromMinutes(2)
            });

            RunNonPrefixCommands();

            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new String[] { "!" },
                EnableMentionPrefix = true,
                EnableDms = false,
                EnableDefaultHelp = false
            };

            // Prefix commands
            PrefixCommands = Client.UseCommandsNext(commandsConfig);
            //
            PrefixCommands.RegisterCommands<src.Commands.FunCommands>();
            PrefixCommands.RegisterCommands<src.Commands.MathCommands>();
            PrefixCommands.RegisterCommands<src.Commands.TimeCommands>();
            PrefixCommands.RegisterCommands<src.Commands.InfoCommands>();
            PrefixCommands.RegisterCommands<src.Commands.TempCommands>();
            PrefixCommands.RegisterCommands<src.Commands.FinanceComands>();
            PrefixCommands.RegisterCommands<src.Commands.NameCommands>();

            // Slash commands
            SlashCommands = Client.UseSlashCommands();
            //
            SlashCommands.RegisterCommands<src.SlashCommands.TimeCommands>(806172073637969951);

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
