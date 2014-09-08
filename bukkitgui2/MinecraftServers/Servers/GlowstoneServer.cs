// GlowstoneServer.cs in bukkitgui2/bukkitgui2
// Created 2014/09/08
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System.Diagnostics;
using System.IO;
using System.Threading;
using Net.Bertware.Bukkitgui2.AddOn.Starter;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.Core.Util.Web;
using Net.Bertware.Bukkitgui2.MinecraftServers.Tools;
using Net.Bertware.Bukkitgui2.Properties;

namespace Net.Bertware.Bukkitgui2.MinecraftServers.Servers
{
	public class GlowstoneServer : MinecraftServerBase
	{
		public GlowstoneServer()
		{
			Name = "Glowstone";
			Site = "http://www.glowstone.net/";
			Logo = Resources.glowstone_logo;

			CanFetchBetaVersion = false;
			CanFetchDevVersion = false;
			CanFetchRecommendedVersion = false;
			CanDownloadBetaVersion = false;
			CanDownloadDevVersion = false;
			CanDownloadRecommendedVersion = true;

			CanGetCurrentVersion = false;

			SupportsPlugins = true;
		}


		public override string GetLaunchFlags(string defaultFlags = "")
		{
			return "-nojline" + defaultFlags;
		}

		public override bool DownloadRecommendedVersion(string targetfile)
		{
			string source =
				"http://ci.chrisgward.com/job/Glowstone/lastStableBuild/artifact/build/distributions/glowstone-0.0.1-SNAPSHOT.jar";
			WebUtil.DownloadFile(source, targetfile, true, true);
			return true;
		}

		public MinecraftServerVersion GetCurrentVersionObject(string file)
		{
			string versionString;
			string java = Starter.GetSelectedJavaPath();
			Process p = new Process
			{
				StartInfo = new ProcessStartInfo(java)
				{
					RedirectStandardOutput = true,
					Arguments = " -Xmx32M -jar \"" + file + "\" -v",
					CreateNoWindow = true,
					UseShellExecute = false
				}
			};

			Logger.Log(LogLevel.Info, "GlowstoneServer", "Starting process for version check",
				"\"" + p.StartInfo.FileName + "\"" + p.StartInfo.Arguments);

			p.Start();

			using (StreamReader sr = new StreamReader(p.StandardOutput.BaseStream))
			{
				for (int i = 0; i < 8; i++)
				{
					int peek = sr.Peek();
					if (peek > 0) continue;
					Thread.Sleep(250);
				}

				versionString = sr.ReadToEnd();
			}

			return new MinecraftServerVersion(versionString);
		}
	}
}