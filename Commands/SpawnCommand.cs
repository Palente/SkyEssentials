using MiNET.Plugins.Attributes;
using OpenAPI.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyEssentials.Commands
{
    class SpawnCommand
    {
        private readonly SkyEssentials Plugin;
        public SpawnCommand(SkyEssentials caller) => Plugin = caller;

        [Command(Name = "spawn", Description ="Teleport to spawn")]
        public void Spawn(OpenPlayer player)
        {
            player.Teleport(player.Level.SpawnPoint);
            player.SendMessage("Telported to spawn");
        }

        [Command(Name = "setworldspawn", Description = "Set World Spawn")]
        public void SetWorldSpawn(OpenPlayer player)
        {
            player.Level.SpawnPoint = player.KnownPosition;
            player.SendMessage("The world spawn was set");
        }
    }
}
