// JsonApiServer.cs in bukkitgui2/bukkitgui2
// Created 2014/02/02
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.IO;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.AddOn.Starter;
using Net.Bertware.Bukkitgui2.Core.FileLocation;
using Net.Bertware.Bukkitgui2.MinecraftServers.Tools;
using Net.Bertware.Bukkitgui2.Properties;

namespace Net.Bertware.Bukkitgui2.MinecraftServers.Servers
{
	internal class JsonApiServer : MinecraftServerBase
	{
		public JsonApiServer()
		{
			Name = "JsonApi";
			Logo = Resources.jsonapi_logo;
			Site = "http://mcjsonapi.com/";
			HasCustomAssembly = true;
			CustomAssembly = ""; // will be set in preparelaunch
			SupportsPlugins = false; //disable plugin manager on this one
			HasCustomSettingsControl = true;
			CustomSettingsControl = new JsonApiCredentialsSettingsControl();
			IsLocal = false;
		}

		public override void PrepareLaunch()
		{
			// Extract the assembly
			CustomAssembly = Fl.SafeLocation(RequestFile.Temp) + "connector.exe";
			using (FileStream fs = File.Create(CustomAssembly))
			{
				fs.Write(Resources.JsonApiConnector, 0, Resources.JsonApiConnector.Length);
			}
		}

		public override string GetLaunchParameters(string defaultParameters = "")
		{
			Control control = Starter.GetCustomSettingsControl();
			if (!(control is JsonApiCredentialsSettingsControl)) throw new Exception("Couldn't retrieve parameters");

			JsonApiCredentialsSettingsControl cred = (JsonApiCredentialsSettingsControl) control;

			return "-u=" + cred.Username + " -p=" + cred.Password + " -s=" + cred.Salt + " -host=" + cred.Host +
			       " -port=" + cred.Port + " -api=1 -filter";
		}
	}
}