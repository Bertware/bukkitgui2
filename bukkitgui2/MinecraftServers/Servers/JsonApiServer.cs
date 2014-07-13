// JsonApiServer.cs in bukkitgui2/bukkitgui2
// Created 2014/02/02
// Last edited at 2014/07/13 14:01
// ©Bertware, visit http://bertware.net

using System.Reflection;
using global::Net.Bertware.Bukkitgui2.MinecraftServers.Tools.global;
using Net.Bertware.Bukkitgui2.Properties;

namespace Net.Bertware.Bukkitgui2.MinecraftServers.Servers
{
	internal class JsonApiServer : MinecraftServerBase
	{
		public JsonApiServer()
		{
			Name = "JsonApi";

			CustomAssembly = Assembly.Load(Resources.JsonApiConnector);
			SupportsPlugins = false; //disable plugin manager on this one
			CustomSettingsControl = new JsonApiCredentialsSettingsControl();
		}
	}
}