namespace SkyEssentials.Commands
{
    using MiNET.Plugins.Attributes;
    using OpenAPI.Player;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="TellCommand" />.
    /// </summary>
    public class TellCommand
    {
        /// <summary>
        /// Defines the Plugin.
        /// </summary>
        public SkyEssentials Plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="TellCommand"/> class.
        /// </summary>
        /// <param name="caller">The caller<see cref="SkyEssentials"/>.</param>
        public TellCommand(SkyEssentials caller) => Plugin = caller;

        /// <summary>
        /// Defines the LastMessages.
        /// </summary>
        public Dictionary<string, string> LastMessages = new Dictionary<string, string>();

        /// <summary>
        /// The Tell.
        /// </summary>
        /// <param name="sender">The sender<see cref="OpenPlayer"/>.</param>
        /// <param name="receiverName">The receiverName<see cref="string"/>.</param>
        /// <param name="message">The message<see cref="string[]"/>.</param>
        [Command(Name = "tell", Description = "Send a private message to a player", Aliases = new string[] { "msg" })]
        public void Tell(OpenPlayer sender, string receiverName, params string[] message)
        {
            //OnepnPlayer is not recognized as an Attribute on Minecraft
            var receiver = Plugin.GetPlayer(receiverName);
            if (receiver is null)
            {
                sender.SendMessage("This player doesn't exist");
                return;
            }
            if (sender.Equals(receiver))
            {
                sender.SendMessage("You can not send a message to yourself!");
                return;
            }
            sender.SendMessage($"[Me => {receiver.Username}] : §6{string.Join(" ", message)}");
            receiver.SendMessage($"[{sender.Username} => Me] : §6{string.Join(" ", message)}");
            LastMessages[receiver.Username] = sender.Username;
        }

        /// <summary>
        /// The Reply.
        /// </summary>
        /// <param name="sender">The sender<see cref="OpenPlayer"/>.</param>
        /// <param name="msgArray">The msgArray<see cref="string[]"/>.</param>
        [Command(Name = "reply", Description = "Reply To your latest private messages")]
        public void Reply(OpenPlayer sender, params string[] msgArray)
        {
            if (!LastMessages.ContainsKey(sender.Username))
            {
                sender.SendMessage("You didn't receive any private message");
                return;
            }
            var receiver = Plugin.GetPlayer(LastMessages[sender.Username]);
            if (receiver is null)
            {
                sender.SendMessage($"The player '{LastMessages[sender.Username] }' is no more online");
                return;
            }
            sender.SendMessage($"[Me => {receiver.Username}] : §6{string.Join(" ", msgArray)}");
            receiver.SendMessage($"[{sender.Username} => Me] : §6{string.Join(" ", msgArray)}");
        }
    }
}
