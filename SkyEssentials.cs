namespace SkyEssentials
{
    using global::SkyEssentials.Commands;
    using MiNET.Effects;
    using OpenAPI;
    using OpenAPI.Permission;
    using OpenAPI.Player;
    using OpenAPI.Plugins;
    using System;

    /// <summary>
    /// Defines the <see cref="SkyEssentials" />.
    /// </summary>
    [OpenPluginInfo(Author = "Palente", Name = "SkyEssentials", Version = "0.0.3", Website = "https://github.com/Palente")]
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

            api.CommandManager.LoadCommands(new TimeCommand(this));
            api.CommandManager.LoadCommands(new EffectCommand(this));
            api.CommandManager.LoadCommands(new SpawnCommand(this));
            api.CommandManager.LoadCommands(new GamemodeCommand(this));
            api.CommandManager.LoadCommands(new TestCommand(this));

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


        public static EffectType? EffectTypeFromName(string effectName)
        {
            effectName = effectName.ToLower();
            foreach(EffectType effect in Enum.GetValues(typeof(EffectType))){
                if (effect.ToString().ToLower() == effectName)
                    return effect;
            }
            return null;
        }
        //it took me a year to do it... just because we can not create a new instance of Effect ...
        public static Effect? GetEffect(EffectType type)
        {
            return type switch
            {
                EffectType.Speed => new Speed(),
                EffectType.Slowness => new Slowness(),
                EffectType.Haste => new Haste(),
                EffectType.MiningFatigue => new MiningFatigue(),
                EffectType.Strength => new Strength(),
                EffectType.InstantHealth => new InstantHealth(),
                EffectType.InstantDamage => new InstantDamage(),
                EffectType.JumpBoost => new JumpBoost(),
                EffectType.Nausea => new Nausea(),
                EffectType.Regeneration => new Regeneration(),
                EffectType.Resistance => new Resistance(),
                EffectType.FireResistance => new FireResistance(),
                EffectType.WaterBreathing => new WaterBreathing(),
                EffectType.Invisibility => new Invisibility(),
                EffectType.Blindness => new Blindness(),
                EffectType.NightVision => new NightVision(),
                EffectType.Hunger => new Hunger(),
                EffectType.Weakness => new Weakness(),
                EffectType.Poison => new Poison(),
                EffectType.Wither => new Wither(),
                EffectType.HealthBoost => new HealthBoost(),
                EffectType.Absorption => new Absorption(),
                EffectType.Saturation => new Saturation(),
                _ => null,
            };
        }
    }
}
