// JsonApiServer.cs in bukkitgui2/bukkitgui2
// Created 2014/02/02
// Last edited at 2014/07/13 14:01
// ©Bertware, visit http://bertware.net

using System;
using System.Reflection;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.AddOn.Starter;
using Net.Bertware.Bukkitgui2.MinecraftServers.Tools;
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

		public override string GetLaunchParameters(string defaultParameters = "")
		{
			Control control =  Starter.GetCustomSettingsControl();
			if (! (control is JsonApiCredentialsSettingsControl)) throw new Exception("Couldn't retrieve parameters");

			JsonApiCredentialsSettingsControl cred = (JsonApiCredentialsSettingsControl) control;

			return "-u=" + cred.Username + " -p=" + cred.Password + " -s=" + cred.Salt + " -host=" + cred.Host + " -port=" +
			       cred.Port;
		}
	}
}