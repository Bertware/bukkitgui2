using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bukkitgui2.MinecraftServers.Servers
{
	class SpigotServer : MinecraftServerBase
	{
        public override string Name
        {
            get { return "Spigot"; }
        }

        public override string Site
        {
            get
            {
                return "http://spigot.net";
            }
        }
	}
}
