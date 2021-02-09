using MiNET.Plugins.Attributes;
using OpenAPI.Player;

namespace SkyEssentials.Commands
{
    public class SayCommand
    {
        private readonly SkyEssentials Plugin;
        public SayCommand(SkyEssentials caller) => Plugin = caller;
        [Command(Name ="say", Description ="Broadcast a message", Permission = "skyessentials.command.say")]
        public void Say(OpenPlayer player, params string[] message)
        {
            Plugin.BroadcastMessage($"§d[{player.Username}] §f{string.Join(" ", message)}");
        }
    }
}
