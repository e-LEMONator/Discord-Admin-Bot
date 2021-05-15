using DSharpPlus;
using System;
using System.Threading.Tasks;

namespace Discord_Admin_Bot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string Token = System.IO.File.ReadAllText("CHANGEME TOKEN");
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = Token, 
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            });

            discord.MessageCreated += async (s, e) =>
            {
                if (e.Message.Content.ToLower().StartsWith("ping") && e.Channel.Id == 842912267925848094)
                {
                    await e.Message.RespondAsync("pong!");
                }
                //if (e.Message.Content.ToLower().StartsWith("ping"))                    
            };

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
