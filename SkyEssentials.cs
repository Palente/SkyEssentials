namespace SkyEssentials
{
    using OpenAPI;
    using OpenAPI.Player;
    using OpenAPI.Plugins;
    using System;

    /// <summary>
    /// Defines the <see cref="SkyEssentials" />.
    /// </summary>
    [OpenPluginInfo(Author = "Palente", Name = "SkyEssentials", Version = "0.0.1", Website = "https://github.com/Palente")]
    public class SkyEssentials : OpenPlugin
    {
        /// <summary>
        /// Defines the Api.
        /// </summary>
        public OpenApi Api;

        /// <summary>
        /// The Disabled.
        /// </summary>
        /// <param name="api">The api<see cref="OpenApi"/>.</param>
        public override void Disabled(OpenApi api)
        {
            Console.WriteLine("Disabled!");
        }

        /// <summary>
        /// The Enabled.
        /// </summary>
        /// <param name="api">The api<see cref="OpenApi"/>.</param>
        public override void Enabled(OpenApi api)
        {
            Console.WriteLine("Enabled!");
            api.CommandManager.LoadCommands(new OpCommand());
            api.CommandManager.LoadCommands(new PluginsCommand(api));
            api.CommandManager.LoadCommands(new TellCommand(this));
            api.EventDispatcher.RegisterEvents(new Events());
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
    }
}
