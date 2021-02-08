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
            player.SendMessage("Tested");
        }
    }
}
