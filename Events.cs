namespace SkyEssentials
{
    using OpenAPI.Events;
    using OpenAPI.Events.Entity;
    using OpenAPI.Events.Player;
    using OpenAPI.Player;
    using System;

    /// <summary>
    /// Defines the <see cref="Events" />.
    /// </summary>
    public class Events : IEventHandler
    {
        /// <summary>
        /// Defines the Plugin.
        /// </summary>
        public SkyEssentials Plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="Events"/> class.
        /// </summary>
        /// <param name="caller">The caller<see cref="SkyEssentials"/>.</param>
        public Events(SkyEssentials caller) => Plugin = caller;

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
            Plugin.BroadcastMessage($"§e[§a+§e] §6{player.Username} §fjust joined!");
        }

        /// <summary>
        /// The OnChat.
        /// </summary>
        /// <param name="e">The e<see cref="PlayerChatEvent"/>.</param>
        [EventHandler]
        public void OnChat(PlayerChatEvent e)
        {
        }

        /// <summary>
        /// The OnEntityKilled.
        /// </summary>
        /// <param name="e">The e<see cref="EntityKilledEvent"/>.</param>
        /*[EventHandler]
        public void OnEntityKilled(EntityKilledEvent e)
        {
            //Fix some bugs
            if (!(e.Entity is OpenPlayer))
                return;
            var player = (OpenPlayer)e.Entity;
            e.SetCancelled(true);
            if (player.Level.KeepInventory)
                player.DropInventory();
            player.HealthManager.Health = player.HealthManager.MaxHealth;
            player.Teleport(player.Level.SpawnPoint);
            player.RemoveAllEffects();
            player.HungerManager.Hunger = player.HungerManager.MaxHunger;
            //Yeah i should do better messages
            Plugin.BroadcastMessage($"{player.Username} is dead");
        }*/
    }
}
