using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using src.FinancialClasses;

namespace src.Commands
{
    public class FinanceComands : BaseCommandModule
    {
        [Command("convert")]
        public async Task ConvertCommand(CommandContext ctx, string amount, string from, string command, string target)
        {
            if (!isDecimal(amount) || from.Length != 3 || command.Length != 2 || target.Length != 3)
            {
                await ErrorMessage(ctx, "Bad data");
                return;
            }

            decimal result = await Finance.Exchange(amount, from.ToUpper(), target.ToUpper());
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder()
            {
                Color = DiscordColor.Magenta,
                Title = $"Converting {from.ToUpper()} to {target.ToUpper()}",
                Description = $"{amount} {from.ToUpper()} = {result} {target.ToUpper()}"
            };

            await ctx.Message.RespondAsync(embed);
        }

        [Command("compare")]
        public async Task CompareCommand(CommandContext ctx, string fromvalue, string from, string targetvalue, string target)
        {
            if (!isDecimal(fromvalue) || from.Length != 3 || !isDecimal(targetvalue) || target.Length != 3)
            {
                await ErrorMessage(ctx, "Bad data");
                return;
            }

            decimal fromResult = await Finance.Exchange(fromvalue, from.ToUpper(), "USD");
            decimal targetResult = await Finance.Exchange(targetvalue, target.ToUpper(), "USD");

            string winnerValue = string.Empty;
            string winnerCurrency = string.Empty;
            string loserValue = string.Empty;
            string loserCurrencty = string.Empty;
            decimal result = 0;

            if (fromResult >= targetResult)
            {
                winnerValue = fromvalue;
                winnerCurrency = from.ToUpper();
                loserValue = targetvalue;
                loserCurrencty = target.ToUpper();
                result = fromResult - targetResult;
            }
            else
            {
                winnerValue = targetvalue;
                winnerCurrency = target.ToUpper();
                loserValue = fromvalue;
                loserCurrencty = from.ToUpper();
                result = targetResult - fromResult;
            }

            DiscordEmbedBuilder embed = new DiscordEmbedBuilder()
            {
                Color = DiscordColor.Magenta,
                Title = $"Currency comparison",
                Description = $"{fromvalue} {from.ToUpper()} = {fromResult} USD\n" +
                            $"{targetvalue} {target.ToUpper()} = {targetResult} USD\n" +
                            $"{winnerValue} {winnerCurrency} is {ResultBuilder(fromResult, targetResult)}% more then {loserValue} {loserCurrencty}\n" +
                            $"Differentiation is {result} USD"
            };

            await ctx.Message.RespondAsync(embed);
        }

        [Command("compare")]
        public async Task CompareCommand(CommandContext ctx, string fromvalue, string from, string targetvalue, string target, string additional)
        {
            if (!isDecimal(fromvalue) || from.Length != 3 || !isDecimal(targetvalue) || target.Length != 3 || additional.Length != 3)
            {
                await ErrorMessage(ctx, "Bad data");
                return;
            }

            decimal fromResult = await Finance.Exchange(fromvalue, from.ToUpper(), additional.ToUpper());
            decimal targetresult = await Finance.Exchange(targetvalue, target.ToUpper(), additional.ToUpper());

            string winnerValue = string.Empty;
            string winnerCurrency = string.Empty;
            string loserValue = string.Empty;
            string loserCurrencty = string.Empty;
            decimal result = 0;

            if (fromResult > targetresult)
            {
                winnerValue = fromvalue;
                winnerCurrency = from.ToUpper();
                loserValue = targetvalue;
                loserCurrencty = target.ToUpper();
                result = fromResult - targetresult;
            }
            else
            {
                winnerValue = targetvalue;
                winnerCurrency = target.ToUpper();
                loserValue = fromvalue;
                loserCurrencty = from.ToUpper();
                result = targetresult - fromResult;
            }

            

            DiscordEmbedBuilder embed = new DiscordEmbedBuilder()
            {
                Color = DiscordColor.Magenta,
                Title = $"Currency comparison",
                Description = $"{fromvalue} {from} = {fromResult} {additional.ToUpper()}\n" +
                            $"{targetvalue} {target} = {targetresult} {additional.ToUpper()}\n" +
                            $"{winnerValue} {winnerCurrency} is {ResultBuilder(fromResult, targetresult)}% more then {loserValue} {loserCurrencty}\n" +
                            $"Differentiation is {result} {additional.ToUpper()}"
            };

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

        public static bool isDecimal(string input)
        {
            return decimal.TryParse(input, out _);
        }

        public static string ResultBuilder(decimal a, decimal b)
        {
            decimal result;
            if (a > b)
                result = a / (b / 100);
            else
                result = b / (a / 100);

            int rofl = Convert.ToInt32(result) - 100;

            return rofl.ToString();
        }
    }
}
