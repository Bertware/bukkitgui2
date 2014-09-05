// JsonApi2Server.cs in bukkitgui2/bukkitgui2
// Created 2014/09/05
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
	internal class JsonApi2Server : MinecraftServerBase
	{
		public JsonApi2Server()
		{
			Name = "JsonApi API v2";
			Logo = Resources.jsonapi_logo;
			Site = "http://mcjsonapi.com/";
			HasCustomAssembly = true;
			CustomAssembly = ""; // will be set in preparelaunch
			SupportsPlugins = false; //disable plugin manager on this one
			HasCustomSettingsControl = true;
			CustomSettingsControl = new JsonApi2CredentialsSettingsControl();
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
			if (! (control is JsonApi2CredentialsSettingsControl)) throw new Exception("Couldn't retrieve parameters");

			JsonApi2CredentialsSettingsControl cred = (JsonApi2CredentialsSettingsControl) control;

			return "-u=" + cred.Username + " -p=" + cred.Password + " -host=" + cred.Host +
			       " -port=" +
			       cred.Port;
		}
	}
}