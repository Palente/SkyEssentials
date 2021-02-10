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
            Effect effect = null;
            switch (type)
            {
                case EffectType.Speed:
                    effect = new Speed();
                    break;
                case EffectType.Slowness:
                    effect = new Slowness();
                    break;
                case EffectType.Haste:
                    effect = new Haste();
                    break;
                case EffectType.MiningFatigue:
                    effect = new MiningFatigue();
                    break;
                case EffectType.Strength:
                    effect = new Strength();
                    break;
                case EffectType.InstantHealth:
                    effect = new InstantHealth();
                    break;
                case EffectType.InstantDamage:
                    effect = new InstantDamage();
                    break;
                case EffectType.JumpBoost:
                    effect = new JumpBoost();
                    break;
                case EffectType.Nausea:
                    effect = new Nausea();
                    break;
                case EffectType.Regeneration:
                    effect = new Regeneration();
                    break;
                case EffectType.Resistance:
                    effect = new Resistance();
                    break;
                case EffectType.FireResistance:
                    effect = new FireResistance();
                    break;
                case EffectType.WaterBreathing:
                    effect = new WaterBreathing();
                    break;
                case EffectType.Invisibility:
                    effect = new Invisibility();
                    break;
                case EffectType.Blindness:
                    effect = new Blindness();
                    break;
                case EffectType.NightVision:
                    effect = new NightVision();
                    break;
                case EffectType.Hunger:
                    effect = new Hunger();
                    break;
                case EffectType.Weakness:
                    effect = new Weakness();
                    break;
                case EffectType.Poison:
                    effect = new Poison();
                    break;
                case EffectType.Wither:
                    effect = new Wither();
                    break;
                case EffectType.HealthBoost:
                    effect = new HealthBoost();
                    break;
                case EffectType.Absorption:
                    effect = new Absorption();
                    break;
                case EffectType.Saturation:
                    effect = new Saturation();
                    break;
            }
            return effect;
        }
    }
}
