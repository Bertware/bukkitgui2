// SpigotServer.cs in bukkitgui2/bukkitgui2
// Created 2014/02/02
// ©Bertware, visit http://bertware.net

using Net.Bertware.Bukkitgui2.Properties;

namespace Net.Bertware.Bukkitgui2.MinecraftServers.Servers
{
	internal class SpigotServer : MinecraftServerBase
	{
		public SpigotServer()
		{
			Name = "Spigot";
			Site = "http://minecraft.net";
			Logo = Resources.spigot_logo;

			CanDownloadRecommendedVersion = true;
			//default value for boolean is false, so all other features are disabled by default
		}
	}
}