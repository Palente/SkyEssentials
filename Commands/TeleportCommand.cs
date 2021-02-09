using MiNET.Plugins.Attributes;
using OpenAPI.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyEssentials.Commands
{
    public class TeleportCommand
    {
        private readonly SkyEssentials Plugin;
        public TeleportCommand(SkyEssentials caller) => Plugin = caller;
        [Command(Name = "teleport", Description = "Teleport to a player")]
        public void Teleport(OpenPlayer player, string playerName)
        {
            var player2 = Plugin.GetPlayer(playerName);
            if(player2 is null)
            {
                player.SendMessage("this player doesn't exist");
                return;
            }
            player.Teleport(player2.KnownPosition);
        }
        [Command(Name = "teleport", Description = "Teleport a player to a player")]
        public void TeleportPlayer(OpenPlayer sender, string playerName, string playerName2)
        {
            var player = Plugin.GetPlayer(playerName);
            if (player is null)
            {
                sender.SendMessage($"the player '{playerName}' doesn't exist");
                return;
            }
            var player2 = Plugin.GetPlayer(playerName2);
            if (player2 is null)
            {
                sender.SendMessage($"the player '{playerName2}' doesn't exist");
                return;
            }
            Plugin.BroadcastMessage($"§8[§o{player.Username} got teleported to {player2.Username} §r§8]");
            player.Teleport(player2.KnownPosition);
        }
    }
}
