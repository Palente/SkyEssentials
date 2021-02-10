using MiNET.Plugins.Attributes;
using MiNET.Worlds;
using OpenAPI.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyEssentials.Commands
{
    public class GamemodeCommand
    {
        private readonly SkyEssentials Plugin;
        public GamemodeCommand(SkyEssentials caller) => Plugin = caller;
        [Command(Name = "gamemode", Description = "Set gamemode")]
        public void Gamemode(OpenPlayer player, GameMode gameMode)
        {
            player.SetGamemode(gameMode);
            player.SendMessage($"Your gamemode is set to {gameMode.ToString()}");
        }
        [Command(Name = "gamemode", Description = "Set gamemode")]
        public void Gamemode(OpenPlayer sender, string playerName, GameMode gameMode)
        {
            var player = Plugin.GetPlayer(playerName);
            if (player is null)
            {
                sender.SendMessage("this player doesn't exist");
                return;
            }
            player.SetGamemode(gameMode);
            player.SendMessage($"Your gamemode is set to {gameMode.ToString()}");
            sender.SendMessage($"The gamemode of {player.Username} is set to {gameMode.ToString()}");
        }
    }
}
