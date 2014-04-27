using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net.Bertware.Bukkitgui2.MinecraftServers.Servers
{
	class JsonApiServer : MinecraftServerBase
	{
        public override string Name
        {
            get { return "JsonApi"; }
        }

        public override string Site
        {
            get
            {
                return "http://minecraft.net";
            }
        }
	}
}
