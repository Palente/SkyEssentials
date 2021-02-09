using MiNET.Items;
using MiNET.Plugins.Attributes;
using OpenAPI.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyEssentials.Commands
{
    public class GiveCommand
    {
        [Command(Name ="give", Description = "give an item")]
        public void Give(OpenPlayer player, int id, int amount = 1)
        {
            if (amount < 1) return;
            var item = ItemFactory.GetItem((short)id, 0, amount);
            player.Inventory.AddItem(item, true);
            player.SendMessage($"You received {item.ToString()} * {amount}");
        }
        [Command(Name = "give", Description = "give an item")]
        public void Give(OpenPlayer player, string name, int amount = 1)
        {
            if (amount < 1) return;
            var item = ItemFactory.GetItem(name, 0, amount);
            player.Inventory.AddItem(item, true);
            player.SendMessage($"You received {name} * {amount}");
        }
    }
}
