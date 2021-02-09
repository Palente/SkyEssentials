namespace SkyEssentials.Commands
{
    using MiNET.Plugins.Attributes;
    using OpenAPI.Player;

    /// <summary>
    /// Defines the <see cref="OpCommand" />.
    /// </summary>
    public class OpCommand
    {
        /// <summary>
        /// The Test.
        /// </summary>
        /// <param name="player">The player<see cref="OpenPlayer"/>.</param>
        [Command(Description = "test")]
        public void Test(OpenPlayer player)
        {
            player.SendMessage("{text:\"Click.\",clickEvent:{action:open_url,value:\"http://stackoverflow.com/q/34635271\"}}", type: MiNET.MessageType.Raw);
        }
    }
}
