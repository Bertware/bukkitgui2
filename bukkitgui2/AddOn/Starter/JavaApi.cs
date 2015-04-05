// JavaApi.cs in bukkitgui2/bukkitgui2
// Created 2014/02/22
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.Core;

namespace Net.Bertware.Bukkitgui2.AddOn.Starter
{
	internal static class JavaApi
	{
		private static Boolean _initialized;

		private static string _jre6X32 = "";

		private static string _jre6X64 = "";

		private static string _jre7X32 = "";

		private static string _jre7X64 = "";

		private static string _jre8X32 = "";

		private static string _jre8X64 = "";

		/// <summary>
		///     Initialize the class, check available versions and paths
		/// </summary>
		public static void Initialize()
		{
			// TODO: BETTER API, REGISTRY SEARCH

			if (Directory.Exists(ProgramFilesx86() + "\\Java\\"))
			{
				foreach (string dir in Directory.GetDirectories(ProgramFilesx86() + "\\Java\\"))
				{
					if ((dir.Contains("jre6") || dir.Contains("jre1.6")) && File.Exists(dir + "\\bin\\java.exe"))
						_jre6X32 = dir + "\\bin\\java.exe";
					if ((dir.Contains("jre7") || dir.Contains("jre1.7")) && File.Exists(dir + "\\bin\\java.exe"))
						_jre7X32 = dir + "\\bin\\java.exe";
					if ((dir.Contains("jre8") || dir.Contains("jre1.8")) && File.Exists(dir + "\\bin\\java.exe"))
						_jre8X32 = dir + "\\bin\\java.exe";
				}
			}

			if (Directory.Exists(ProgramFiles() + "\\Java\\") & Share.Is64Bit)
			{
				foreach (string dir in Directory.GetDirectories(ProgramFiles() + "\\Java\\"))
				{
					if ((dir.Contains("jre6") || dir.Contains("jre1.6")) && File.Exists(dir + "\\bin\\java.exe"))
						_jre6X64 = dir + "\\bin\\java.exe";
					if ((dir.Contains("jre7") || dir.Contains("jre1.7")) && File.Exists(dir + "\\bin\\java.exe"))
						_jre7X64 = dir + "\\bin\\java.exe";
					if ((dir.Contains("jre8") || dir.Contains("jre1.8")) && File.Exists(dir + "\\bin\\java.exe"))
						_jre8X64 = dir + "\\bin\\java.exe";
				}
			}
			_initialized = true;
		}

		/// <summary>
		///     Returns true if a given version if installed
		/// </summary>
		/// <param name="jreVersion">The java version to check</param>
		/// <returns></returns>
		public static Boolean IsInstalled(JavaVersion jreVersion)
		{
			if (!_initialized)
			{
				Initialize();
			}
			switch (jreVersion)
			{
				case JavaVersion.Jre6X32:
					return !string.IsNullOrEmpty(_jre6X32);
				case JavaVersion.Jre6X64:
					return !string.IsNullOrEmpty(_jre6X64);
				case JavaVersion.Jre7X32:
					return !string.IsNullOrEmpty(_jre7X32);
				case JavaVersion.Jre7X64:
					return !string.IsNullOrEmpty(_jre7X64);
				case JavaVersion.Jre8X32:
					return !string.IsNullOrEmpty(_jre8X32);
				case JavaVersion.Jre8X64:
					return !string.IsNullOrEmpty(_jre8X64);
				case JavaVersion.Custom:
					return true;
				default:
					return false;
			}
		}

		/// <summary>
		///     Get the absolute location of an installed java version
		/// </summary>
		/// <param name="jreVersion">The java version to retrieve</param>
		/// <returns>Returns the absolute path to java.exe</returns>
		public static string GetJavaPath(JavaVersion jreVersion)
		{
			if (!_initialized)
			{
				Initialize();
			}
			switch (jreVersion)
			{
				case JavaVersion.Jre6X32:
					return _jre6X32;
				case JavaVersion.Jre6X64:
					return _jre6X64;
				case JavaVersion.Jre7X32:
					return _jre7X32;
				case JavaVersion.Jre7X64:
					return _jre7X64;
				case JavaVersion.Jre8X32:
					return _jre8X32;
				case JavaVersion.Jre8X64:
					return _jre8X64;
				case JavaVersion.Custom:
					string path = Bukkitgui2.Core.Configuration.Config.ReadString("starter", "java_custom", "");
					if (string.IsNullOrEmpty(path))
					{
						OpenFileDialog ofd = new OpenFileDialog
						{
							Title = "Select java.exe",
							Filter = "Java executables (*.exe) |*.exe|All Files (*.*)|*.*"
						};
						ofd.ShowDialog();
						path = ofd.FileName;
						Core.Configuration.Config.WriteString("starter", "java_custom", path);
					}
					return path;
				default:
					return null;
			}
		}

		/// <summary>
		///     Check if a java version is 32 bit
		/// </summary>
		/// <param name="version">the version to check</param>
		/// <returns></returns>
		public static bool Is32Bitversion(JavaVersion version)
		{
			return (version.ToString().ToLower().Contains("x32"));
		}

		private static string ProgramFilesx86()
		{
			if (8 == IntPtr.Size
			    || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
			{
				return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
			}

			return Environment.GetEnvironmentVariable("ProgramFiles");
		}

		private static string ProgramFiles()
		{
			if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("ProgramW6432")))
				return (Environment.GetEnvironmentVariable("ProgramW6432"));
			return Environment.GetEnvironmentVariable("ProgramFiles");
		}
	}

	public enum JavaVersion
	{
		Jre6X32,

		Jre6X64,

		Jre7X32,

		Jre7X64,

		Jre8X32,

		Jre8X64,

		Custom
	}
}