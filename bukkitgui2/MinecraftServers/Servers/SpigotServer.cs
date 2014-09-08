// SpigotServer.cs in bukkitgui2/bukkitgui2
// Created 2014/02/02
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using Net.Bertware.Bukkitgui2.Core.Util.Web;
using Net.Bertware.Bukkitgui2.Properties;

namespace Net.Bertware.Bukkitgui2.MinecraftServers.Servers
{
	internal class SpigotServer : MinecraftServerBase
	{
		private const string SourceLatest =
			"http://ci.md-5.net/job/Spigot/lastSuccessfulBuild/artifact/Spigot-Server/target/spigot.jar";

		public SpigotServer()
		{
			Name = "Spigot";
			Site = "http://www.spigotmc.org/";
			Logo = Resources.spigot_logo;

			CanDownloadRecommendedVersion = false;
			CanDownloadBetaVersion = false;
			CanDownloadDevVersion = true;
			//default value for boolean is false, so all other features are disabled by default
		}


		public override bool DownloadDevVersion(string targetfile)
		{
			WebUtil.DownloadFile(SourceLatest, targetfile, true, true);
			return true;
		}
	}
}