using MiNET.Effects;
using MiNET.Plugins.Attributes;
using OpenAPI.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyEssentials.Commands
{
    //Effects are fucked, you still get the effect even after the time passed, clear doesnt work
    class EffectCommand
    {
        private readonly SkyEssentials Plugin;
        public EffectCommand(SkyEssentials caller) => Plugin = caller;

        [Command(Name = "effect clear", Description = "Clear your effects")]
        public void EffectClear(OpenPlayer player)
        {
            //Doesn't work
            player.RemoveAllEffects();
            player.Effects.Clear();
            player.SendMessage("Your removed your effects");
        }

        [Command(Name = "effect clear", Description = "Clear someone's effects")]
        public void EffectClear(OpenPlayer sender, string playerName)
        {
            var player = Plugin.GetPlayer(playerName);
            if (player is null)
            {
                sender.SendMessage("this player doesn't exist");
                return;
            }
            //Doesn't work
            player.RemoveAllEffects();
        }
        //Int is casted to string sometimes so no default value
        [Command(Name = "effect", Description = "Add effect to a player")]
        public void EffectSet(OpenPlayer sender, string playerName, string effectName, int duration, int amplifier)
        {
            var player = Plugin.GetPlayer(playerName);
            if (player is null)
            {
                sender.SendMessage("this player doesn't exist");
                return;
            }
            EffectType? effectType = SkyEssentials.EffectTypeFromName(effectName);
            if(effectType is null)
            {
                sender.SendMessage("This effect doesn't exist");
                return;
            }
            var effect = SkyEssentials.GetEffect((EffectType)effectType);
            if(effect is null)
            {
                //That shouldn't happen but it can even if it should not.
                sender.SendMessage("An error has occured.");
                return;
            }
            effect.Duration = duration;
            effect.Level = amplifier;
            effect.SendAdd(player);
            sender.SendMessage($"You successfully added {effectName} to {playerName}");
        }
        [Command(Name = "effect", Description = "Add effect to a player")]
        public void EffectSet(OpenPlayer sender, string playerName, int EffectId, int duration, int amplifier)
        {
            var player = Plugin.GetPlayer(playerName);
            if (player is null)
            {
                sender.SendMessage("this player doesn't exist");
                return;
            }
            EffectType? effectType = (EffectType?)EffectId;
            if (effectType is null)
            {
                sender.SendMessage("This effect doesn't exist");
                return;
            }
            var effect = SkyEssentials.GetEffect((EffectType)effectType);
            if (effect is null)
            {
                //That shouldn't happen but it can even if it should not.
                sender.SendMessage("An error has occured.");
                return;
            }
            effect.Duration = duration;
            effect.Level = amplifier;
            effect.SendAdd(player);
            sender.SendMessage($"You successfully added {EffectId} to {playerName}");
        }


        [Command(Name = "effect", Description = "Add effect to a player")]
        public void EffectSet(OpenPlayer player, string effectName, int duration, int amplifier)
        {
            EffectType? effectType = SkyEssentials.EffectTypeFromName(effectName);
            if (effectType is null)
            {
                player.SendMessage("This effect doesn't exist");
                return;
            }
            var effect = SkyEssentials.GetEffect((EffectType)effectType);
            if (effect is null)
            {
                //That shouldn't happen but it can even if it should not.
                player.SendMessage("An error has occured.");
                return;
            }
            effect.Duration = duration;
            effect.Level = amplifier;
            effect.SendAdd(player);
            player.SendMessage($"You successfully added {effectName}");
        }
        [Command(Name = "effect", Description = "Add effect to a player")]
        public void EffectSet(OpenPlayer player,int EffectId, int duration, int amplifier)
        {
            EffectType? effectType = (EffectType?)EffectId;
            if (effectType is null)
            {
                player.SendMessage("This effect doesn't exist");
                return;
            }
            var effect = SkyEssentials.GetEffect((EffectType)effectType);
            if (effect is null)
            {
                //That shouldn't happen but it can even if it should not.
                player.SendMessage("An error has occured.");
                return;
            }
            effect.Duration = duration;
            effect.Level = amplifier;
            effect.SendAdd(player);
            player.SendMessage($"You successfully added {effect.ToString()}");
        }


    }
}
