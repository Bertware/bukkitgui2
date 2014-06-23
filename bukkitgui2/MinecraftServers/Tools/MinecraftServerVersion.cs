// MinecraftServerVersion.cs in bukkitgui2/bukkitgui2
// Created 2014/06/23
// Last edited at 2014/06/23 12:32
// ©Bertware, visit http://bertware.net

using System;
using System.Text.RegularExpressions;

namespace Net.Bertware.Bukkitgui2.MinecraftServers.Tools
{
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