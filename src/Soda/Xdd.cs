using Azure.AI.OpenAI;

namespace src.Soda
{
    public class Xdd
    {
        static readonly OpenAIClient client = new OpenAIClient(Pepsi.Get("gpt"));

        public static async Task<string> GetResponse(string prompt)
        {
            string result = "Failed";
            var response = await client.GetChatCompletionsAsync(
                "gpt-3.5-turbo-16k",
                new ChatCompletionsOptions
                {
                    Messages = { new ChatMessage(ChatRole.User, prompt) }
                }
            );


            if (response.Value.Choices.Count > 0)
            {
                string generatedText = response.Value.Choices[0].Message.Content;

                result = generatedText;
            }

            return result;
        }
    }
}