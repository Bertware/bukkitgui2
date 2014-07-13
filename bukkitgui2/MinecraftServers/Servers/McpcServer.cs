// McpcServer.cs in bukkitgui2/bukkitgui2
// Created 2014/02/02
// Last edited at 2014/07/13 14:01
// ©Bertware, visit http://bertware.net

namespace Net.Bertware.Bukkitgui2.MinecraftServers.Servers
{
	internal class McpcServer : MinecraftServerBase
	{
		public McpcServer()
		{
			Name = "MCPC";
			Site = "http://minecraft.net";
			Logo = null;

			CanDownloadRecommendedVersion = true;
			//default value for boolean is false, so all other features are disabled by default
		}
	}
}