// MinecraftServerLoader.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/06/07 20:24
// ©Bertware, visit http://bertware.net

using System.Collections.Generic;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.Core.Util;

namespace Net.Bertware.Bukkitgui2.MinecraftServers
{
	internal static class MinecraftServerLoader
	{
		/// <summary>
		///     Get a list of all available server types
		/// </summary>
		/// <returns></returns>
		internal static Dictionary<string, IMinecraftServer> GetAvailableServers()
		{
			Dictionary<string, IMinecraftServer> servers = new Dictionary<string, IMinecraftServer>();

			foreach (
				IMinecraftServer server in
					DynamicModuleLoader.GetClassesOfType<IMinecraftServer>("Net.Bertware.Bukkitgui2.MinecraftServers.Servers"))
			{
				if (!servers.ContainsKey(server.Name))
				{
					servers.Add(server.Name, server);
				}
				else
				{
					Logger.Log(
						LogLevel.Severe,
						"MinecraftServerLoader",
						"Can't add server to dictionary, duplicate name!",
						server.Name);
				}
			}
			return servers;
		}
	}
}