using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MiNET.Entities;
using MiNET.Worlds;

namespace SkyEssentials
{
    public class CustomEntity : Entity
    {
        public CustomEntity(string entityTypeId, Level level) : base(entityTypeId, level)
        {
        }
    }
}
