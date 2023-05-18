using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Net;
using DSharpPlus.Lavalink;
using DSharpPlus.SlashCommands;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Logging;
using DSharpPlus.VoiceNext;

namespace Stella
{
    internal class Program
    {

        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            var token = Environment.GetEnvironmentVariable("STELLA_TOKEN");
            var serverOne = Environment.GetEnvironmentVariable("STELLA_SERVER1");
            var serverTwo = Environment.GetEnvironmentVariable("STELLA_SERVER2");
            var serverThree = Environment.GetEnvironmentVariable("STELLA_SERVER3");

            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = token,
                TokenType = TokenType.Bot,
                MinimumLogLevel = LogLevel.Debug,
                Intents = DiscordIntents.MessageContents | DiscordIntents.AllUnprivileged
            });

            var commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefixes = new[] { "!" }
            });

            commands.RegisterCommands<Commands>();

            var endpoint = new ConnectionEndpoint
            {
                Hostname = "127.0.0.1",
                Port = 2333
            };

            var lavalinkConfig = new LavalinkConfiguration
            {
                Password = "youshallnotpass",
                RestEndpoint = endpoint,
                SocketEndpoint = endpoint
            };

            var lavalink = discord.UseLavalink();

            var config = new SlashCommandsConfiguration();

            var slashcommands = discord.UseSlashCommands(config);
            discord.UseVoiceNext();
            slashcommands.RegisterCommands<SlashCommands>(Convert.ToUInt64(serverOne));
            slashcommands.RegisterCommands<SlashCommands>(Convert.ToUInt64(serverTwo));
            slashcommands.RegisterCommands<SlashCommands>(Convert.ToUInt64(serverThree));
            var a = slashcommands.RegisteredCommands;


            await discord.ConnectAsync();
            await lavalink.ConnectAsync(lavalinkConfig);
            await Task.Delay(-1);
        }


    }
}