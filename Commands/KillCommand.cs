using MiNET.Plugins.Attributes;
using OpenAPI.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyEssentials.Commands
{
    public class KillCommand
    {
        private readonly SkyEssentials Plugin;
        public KillCommand(SkyEssentials caller) => Plugin = caller;

        [Command(Name = "kill", Description = "Kill a player")]
        public void Kill(OpenPlayer player)
        {
            player.HealthManager.Kill();
        }
        [Command(Name = "kill", Description = "Kill a player")]
        public void Kill(OpenPlayer sender, string playerName)
        {
            var player = Plugin.GetPlayer(playerName);
            if(player is null)
            {
                sender.SendMessage("This player doesn't exist!");
                return;
            }
            player.HealthManager.Kill();
        }
    }
}
