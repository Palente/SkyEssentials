namespace SkyEssentials
{
    using global::SkyEssentials.Commands;
    using OpenAPI;
    using OpenAPI.Permission;
    using OpenAPI.Player;
    using OpenAPI.Plugins;
    using System;

    /// <summary>
    /// Defines the <see cref="SkyEssentials" />.
    /// </summary>
    [OpenPluginInfo(Author = "Palente", Name = "SkyEssentials", Version = "0.0.2", Website = "https://github.com/Palente")]
    public class SkyEssentials : OpenPlugin
    {
        /// <summary>
        /// Defines the Api.
        /// </summary>
        public OpenApi Api;

        /// <summary>
        /// Gets the Permissions.
        /// </summary>
        public PermissionGroup Permissions { get; private set; }

        /// <summary>
        /// Defines the Version of the plugin..
        /// </summary>
        public readonly string Version = "0.0.2";
        public Events Events { get; private set; }
        /// <summary>
        /// Called when the plugin is disabled.
        /// </summary>
        /// <param name="api">The api<see cref="OpenApi"/>.</param>
        public override void Disabled(OpenApi api)
        {
            api.EventDispatcher.UnregisterEvents(Events);
        }

        /// <summary>
        /// Called when the plugin is enabled
        /// </summary>
        /// <param name="api">The api<see cref="OpenApi"/>.</param>
        public override void Enabled(OpenApi api)
        {
            Events = new Events(this);
            api.CommandManager.LoadCommands(new OpCommand());
            api.CommandManager.LoadCommands(new PluginsCommand(api));
            api.CommandManager.LoadCommands(new TellCommand(this));
            api.CommandManager.LoadCommands(new MeCommand(this));
            api.CommandManager.LoadCommands(new ListCommand(this));
            api.CommandManager.LoadCommands(new TeleportCommand(this));
            api.CommandManager.LoadCommands(new SayCommand(this));
            api.CommandManager.LoadCommands(new GiveCommand());
            api.CommandManager.LoadCommands(new KillCommand(this));
            api.EventDispatcher.RegisterEvents(Events);
            Api = api;
        }

        /// <summary>
        /// The GetPlayer.
        /// </summary>
        /// <param name="name">The name<see cref="string"/>.</param>
        /// <returns>The <see cref="OpenPlayer?"/>.</returns>
        public OpenPlayer? GetPlayer(string name)
        {
            var players = Api.PlayerManager.GetPlayers();
            foreach (OpenPlayer player in players)
                if (player.Username.ToLower() == name.ToLower())
                    return player;
            return null;
        }

        /// <summary>
        /// The BroadcastMessage.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        /// <param name="operators">The operators<see cref="bool"/>.</param>
        public void BroadcastMessage(string message, bool operators = false)
        {
            foreach (OpenPlayer player in Api.PlayerManager.GetPlayers())
            {
                if (operators)
                {
                    if (player.Permissions.HasPermission("skyessentials.admin"))
                        player.SendMessage(message);
                }
                else
                    player.SendMessage(message);
            }
        }
    }
}
