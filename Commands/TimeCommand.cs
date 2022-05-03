using MiNET.Plugins.Attributes;
using OpenAPI.Player;

namespace SkyEssentials.Commands
{
    public class TimeCommand
    {
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
            if(time>((float)TimeWorld.TIME_FULL) || time < 0)
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
            TimeWorld time;
            switch (timeName.ToLower())
            {
                case "day":
					time = TimeWorld.TIME_DAY;
                    break;
                case "noon":
					time = TimeWorld.TIME_NOON;
                    break;
                case "sunset":
					time = TimeWorld.TIME_SUNSET;
                    break;
                case "night":
					time = TimeWorld.TIME_NIGHT;
                    break;
                case "midnight":
					time = TimeWorld.TIME_MIDNIGHT;
                    break;
                case "sunrise":
					time = TimeWorld.TIME_SUNRISE;
                    break;
                default:
                    player.SendMessage("This value can not be used!");
                    return;
            }
            player.Level.WorldTime = (long)time;
            player.SendMessage($"You set the time to {timeName}");
        }
    }
    public enum TimeWorld : long
    {
        //Taken from PocketMine
        TIME_DAY = 1000,
        TIME_NOON = 6000,
        TIME_SUNSET = 12000,
        TIME_NIGHT = 13000,
        TIME_MIDNIGHT = 18000,
        TIME_SUNRISE = 23000,
        TIME_FULL = 24000
    }
}
