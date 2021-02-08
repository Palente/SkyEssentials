namespace SkyEssentials
{
    using OpenAPI.Events;
    using OpenAPI.Events.Player;
    using System;

    /// <summary>
    /// Defines the <see cref="Events" />.
    /// </summary>
    public class Events : IEventHandler
    {
        /// <summary>
        /// The OnJoin.
        /// </summary>
        /// <param name="e">The e<see cref="PlayerJoinEvent"/>.</param>
        [EventHandler]
        public void OnJoin(PlayerJoinEvent e)
        {
            var player = e.Player;
            player.PermissionLevel = MiNET.Net.PermissionLevel.Member;
            player.ActionPermissions = MiNET.Net.ActionPermissions.Default;
            player.SendAdventureSettings();
            player.SendMessage("Joined!");
        }
    }
}
