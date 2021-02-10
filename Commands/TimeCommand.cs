using MiNET.Plugins.Attributes;
using OpenAPI.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyEssentials.Commands
{
    public class TimeCommand
    {
        //Taken from PocketMine
        public const long TIME_DAY = 1000;
        public const long TIME_NOON = 6000;
        public const long TIME_SUNSET = 12000;
        public const long TIME_NIGHT = 13000;
        public const long TIME_MIDNIGHT = 18000;
        public const long TIME_SUNRISE = 23000;
        public const long TIME_FULL = 24000;
        private readonly SkyEssentials Plugin;
        public TimeCommand(SkyEssentials caller) => Plugin = caller;

        [Command(Name ="time now", Description = "get the actual time")]
        public void Time(OpenPlayer player)
        {
            //there is no possibility to stop and start the time
            player.SendMessage($"The actual time of this level is {player.Level.WorldTime}");
        }
        [Command(Name = "time set", Description = "set the actual time")]
        public void Time(OpenPlayer player, long time)
        {
            //there is no possibility to stop and start the time
            if(time>TIME_FULL || time < 0)
            {
                player.SendMessage("This value can not be used!");
                return;
            }
            player.Level.WorldTime = time;
            player.SendMessage($"You set the time to {time}");
        }
        [Command(Name = "time set", Description = "set the actual time")]
        public void Time(OpenPlayer player, string timeName)
        {
            //there is no possibility to stop and start the time
            long time = 0;
            switch (timeName.ToLower())
            {
                case "day":
					time = TIME_DAY;
                    break;
                case "noon":
					time = TIME_NOON;
                    break;
                case "sunset":
					time = TIME_SUNSET;
                    break;
                case "night":
					time = TIME_NIGHT;
                    break;
                case "midnight":
					time = TIME_MIDNIGHT;
                    break;
                case "sunrise":
					time = TIME_SUNRISE;
                    break;
                default:
                    player.SendMessage("This value can not be used!");
                    return;
            }
            player.Level.WorldTime = time;
            player.SendMessage($"You set the time to {timeName}");
        }
    }
}
