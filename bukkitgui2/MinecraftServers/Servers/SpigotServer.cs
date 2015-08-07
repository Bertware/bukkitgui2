// SpigotServer.cs in bukkitgui2/bukkitgui2
// Created 2014/02/02
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using MetroFramework;
using Net.Bertware.Bukkitgui2.Core.Util.Web;
using Net.Bertware.Bukkitgui2.Properties;

namespace Net.Bertware.Bukkitgui2.MinecraftServers.Servers
{
	internal class SpigotServer : MinecraftServerBase
	{

		private const string BuildtoolsUrl = "https://hub.spigotmc.org/jenkins/job/BuildTools/lastSuccessfulBuild/artifact/target/BuildTools.jar";

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
			WebUtil.DownloadFile(BuildtoolsUrl,"spigot_buildtools.jar",true,true);
			
			const string gitx86 = "C:\\Program Files (x86)\\Git\\bin\\sh.exe";
			const string gitx64 = "C:\\Program Files\\Git\\bin\\sh.exe";
			string git = null;

			if (File.Exists(gitx86))
			{
				git = gitx86;
			}
			if (File.Exists(gitx64))
			{
				git = gitx64;
			}
			if (git == null)
			{
				if (
					MetroMessageBox.Show(Application.OpenForms[0],
						"You need to install git in order to download spigot. Do you want to open the download page now? Once git is installed you can try again to download spigot.",
						"Git shell not found", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Process.Start("http://git-scm.com/download/win");
				}
				return false;
			}

			// TODO: run buildtools

			return true;
		}
	}
}