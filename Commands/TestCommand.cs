using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MiNET.Plugins.Attributes;

using OpenAPI.Player;

namespace SkyEssentials.Commands
{
    public class TestCommand
    {
        private readonly SkyEssentials _Plugin;
        public TestCommand(SkyEssentials caller) => _Plugin = caller;

        [Command(Name = "testentity", Description = "EntityTesting")]
        public void Test(OpenPlayer player)
        {
            //TODO
        }
    }
}
