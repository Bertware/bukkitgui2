using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net.Bertware.Bukkitgui2.MinecraftServers.Servers
{
	class McpcServer : MinecraftServerBase
	{
        public override string Name
        {
            get { return "Mcpc"; }
        }

        public override string Site
        {
            get
            {
                return "http://www.mcportcentral.co.za";
            }
        }
	}
}
