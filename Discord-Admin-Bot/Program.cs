using Discord_Admin_Bot.Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using System;
using System.Reflection;
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

            var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { "!" }
            });

            commands.RegisterCommands(Assembly.GetExecutingAssembly());

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
