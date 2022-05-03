namespace SkyEssentials.Commands
{
    using MiNET.Plugins.Attributes;
    using OpenAPI;
    using OpenAPI.Player;
    using OpenAPI.Plugins;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="PluginsCommand" />.
    /// </summary>
    public class PluginsCommand
    {
        /// <summary>
        /// Defines the Api.
        /// </summary>
        public OpenApi Api;

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginsCommand"/> class.
        /// </summary>
        /// <param name="api">The api<see cref="OpenApi"/>.</param>
        public PluginsCommand(OpenApi api)
        {
            Api = api;
        }

        /// <summary>
        /// The Plugins.
        /// </summary>
        /// <param name="player">The player<see cref="OpenPlayer"/>.</param>
        [Command(Name = "plugins", Description = "Get a list of plugins used by this server")]
        public void Plugins(OpenPlayer player)
        {
            var plugins = Api.PluginManager.GetLoadedPlugins();
            var result = $"Plugins({plugins.Length}): ";
            foreach (LoadedPlugin plugin in plugins)
            {
                result += $"{(plugin.Enabled ? "§a" : "§c")}{plugin.Info.Name} §ev{plugin.Info.Version}§f, ";
            }
            //used to remove the ", " at the end
            result = result.Remove(result.Length - 2);
            player.SendMessage(result);
        }

        /// <summary>
        /// The About.
        /// </summary>
        /// <param name="player">The player<see cref="OpenPlayer"/>.</param>
        [Command(Name = "about", Description = "Get Information about this server")]
        public void About(OpenPlayer player)
        {
            //I didn't found any properties to get OpenApi Version or MiNET
            player.SendMessage($"This server is running under I don't know?");
        }

        /// <summary>
        /// The About.
        /// </summary>
        /// <param name="player">The player<see cref="OpenPlayer"/>.</param>
        /// <param name="pluginName">The pluginName<see cref="string"/>.</param>
        [Command(Name = "about", Description = "get information about a plugin")]
        public void About(OpenPlayer player, string pluginName)
        {
            var plugin = Api.PluginManager.GetLoadedPlugins().First(pl => pl.Info.Name.ToLower() == pluginName.ToLower());
            if (plugin is null)
            {
                player.SendMessage("This plugin doesn't exist!");
                return;
            }
            player.SendMessage($"§a{plugin.Info.Name} §e<{plugin.Info.Version}> §fAuthor: §3{plugin.Info.Author}");
        }
    }
}
