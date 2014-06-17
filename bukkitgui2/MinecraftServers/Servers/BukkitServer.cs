// BukkitServer.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/06/07 20:24
// ©Bertware, visit http://bertware.net

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using Net.Bertware.Bukkitgui2.AddOn;
using Net.Bertware.Bukkitgui2.AddOn.Starter;
using Net.Bertware.Bukkitgui2.MinecraftServers.Tools.bukkit;
using Net.Bertware.Bukkitgui2.Properties;

namespace Net.Bertware.Bukkitgui2.MinecraftServers.Servers
{
	internal class BukkitServer : MinecraftServerBase
	{
		public override string Name
		{
			get { return "Bukkit"; }
		}

		public override string Site
		{
			get { return "http://bukkit.org"; }
		}

		public override Image Logo
		{
			get { return Resources.bukkit_logo; }
		}

		public override bool CanFetchRecommendedVersion
		{
			get { return true; }
		}

		public override bool CanFetchBetaVersion
		{
			get { return true; }
		}

		public override bool CanFetchDevVersion
		{
			get { return true; }
		}

		public override bool CanDownloadRecommendedVersion
		{
			get { return true; }
		}

		public override bool CanDownloadBetaVersion
		{
			get { return true; }
		}

		public override bool CanDownloadDevVersion
		{
			get { return true; }
		}

		public override bool CanGetCurrentVersion
		{
			get { return true; }
		}

		public override bool SupportsPlugins
		{
			get { return true; }
		}

		public override string GetLaunchFlags(string defaultFlags = "")
		{
			return "-nojline" + defaultFlags;
		}

		public override bool DownloadDevVersion(string targetfile)
		{
			string source = Dlb.GetlatestVersionInfo(Dlb.BukkitVersionType.Dev).FileUrl;
			Core.Util.Web.WebUtil.DownloadFile(source, targetfile, true);
			return true;
		}

		public override bool DownloadBetaVersion(string targetfile)
		{
			string source = Dlb.GetlatestVersionInfo(Dlb.BukkitVersionType.Beta).FileUrl;
			Core.Util.Web.WebUtil.DownloadFile(source, targetfile, true);
			return true;
		}

		public override bool DownloadRecommendedVersion(string targetfile)
		{
			string source = Dlb.GetlatestVersionInfo(Dlb.BukkitVersionType.Rb).FileUrl;
			Core.Util.Web.WebUtil.DownloadFile(source, targetfile, true);
			return true;
		}

		private DlbDownload _lastDevDownload;

		public override string FetchDevVersion
		{
			get
			{
				if (_lastDevDownload == null) _lastDevDownload = Dlb.GetlatestVersionInfo(Dlb.BukkitVersionType.Dev);
				return _lastDevDownload.Version;
			}
		}

		private DlbDownload _lastBetaDownload;

		public override string FetchBetaVersion
		{
			get
			{
				if (_lastBetaDownload == null) _lastBetaDownload = Dlb.GetlatestVersionInfo(Dlb.BukkitVersionType.Beta);
				return _lastBetaDownload.Version;
			}
		}

		private DlbDownload _lastRecommendedDownload;

		public override string FetchRecommendedVersion
		{
			get
			{
				if (_lastRecommendedDownload == null) _lastRecommendedDownload = Dlb.GetlatestVersionInfo(Dlb.BukkitVersionType.Rb);
				return _lastRecommendedDownload.Version;
			}
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
					Arguments = " -Xincgc -XmX32M -jar " + file + " -v",
					CreateNoWindow = true
				}
			};
			p.Start();

			using (StreamReader sr = new StreamReader(p.StandardOutput.BaseStream))
			{
				versionString = sr.ReadToEnd();
			}

			return new MinecraftServerVersion(versionString);
		}
	}

	public class MinecraftServerVersion
	{
		public int Build { get; private set; }
		public string MinecraftVersion { get; private set; }
		public string ServerVersion { get; private set; }

		public MinecraftServerVersion(string versionString)
		{
			Build = ParseVersionString(versionString);
			MinecraftVersion = ParseVersionStringMinecraftVersion(versionString);
			ServerVersion = ParseVersionStringServerVersion(versionString);
		}

		/// <summary>
		///     parse a version string (jenkins etc)
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		private static int ParseVersionString(string text)
		{
			const string pattern = "(#\\d\\d\\d\\d|#\\d\\d\\d|b\\d\\d\\d\\djnks|b\\d\\d\\djnks)";
			Match match = Regex.Match(text, pattern);
			char[] chars =
			{
				'#',
				'b',
				'j',
				'n',
				'k',
				's'
			};

			if (string.IsNullOrEmpty(match.Value))
				return 0;
			return Convert.ToInt32(match.Value.Trim(chars));
		}

		/// <summary>
		///     parse a bukkit version (console output)
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		private static string ParseVersionStringServerVersion(string text)
		{
			const string pattern = "(\\d.\\d.\\d|\\d.\\d)(\\-R\\d|)";
			Match match = Regex.Match(text, pattern);
			if (string.IsNullOrEmpty(match.Value))
				return "unknown";
			return match.Value;
		}

		/// <summary>
		///     parse an MC version. Can be in the same version string as the bukkit version
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		private static string ParseVersionStringMinecraftVersion(string text)
		{
			const string pattern = "MC: (\\d.\\d.\\d|\\d.\\d)";
			Match match = Regex.Match(text, pattern);
			if (string.IsNullOrEmpty(match.Value))
				return "unknown";

			return match.Value;
		}

		public override string ToString()
		{
			return ServerVersion + " (" + MinecraftVersion + ")";
		}
	}
}