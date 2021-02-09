using MiNET.Plugins.Attributes;
using OpenAPI.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyEssentials.Commands
{
    public class MeCommand
    {
        public SkyEssentials Plugin;
        public MeCommand(SkyEssentials caller) => Plugin = caller;
        [Command(Name ="me", Description ="Describe what you are doing")]
        public void Me(OpenPlayer player, params string[] message)
        {
            Plugin.BroadcastMessage($"*{player.Username} §o{string.Join(" ", message)}");
        }
    }
}
