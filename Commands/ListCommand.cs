using MiNET.Plugins.Attributes;
using OpenAPI.Player;

namespace SkyEssentials.Commands
{
    class ListCommand
    {
        public SkyEssentials Plugin;
        public ListCommand(SkyEssentials caller) => Plugin = caller;
        [Command(Name ="list", Description ="Get list of players")]
        public void List(OpenPlayer player)
        {
            var players = Plugin.Api.PlayerManager.GetPlayers();
            var msg = $"There is ({players.Length} players: ";
            foreach (OpenPlayer playerListed in players)
                msg += $"{playerListed.Username}, ";
            player.SendMessage(msg);
        }
    }
}
