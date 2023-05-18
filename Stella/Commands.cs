using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Lavalink;
using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stella
{

    public class Commands : BaseCommandModule
    {

        [Command("ping")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.RespondAsync("Pong!");
        }

        [Command("dnd")]
        public async Task Dnd(CommandContext ctx)
        {
            await ctx.RespondAsync("@everyone It's time for D&D :)");
        }

    }
}