// JavaApi.cs in bukkitgui2/bukkitgui2
// Created 2014/02/22
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Win32;
using Net.Bertware.Bukkitgui2.Core;
using Net.Bertware.Bukkitgui2.Core.Configuration;
using Net.Bertware.Bukkitgui2.Core.Logging;

namespace Net.Bertware.Bukkitgui2.AddOn.Starter
{
	internal static class JavaApi
	{
		private static Boolean _initialized;

		private static Dictionary<JavaVersion, String> _javaPaths;

		/// <summary>
		///     Initialize the class, check available versions and paths
		/// </summary>
		public static void Initialize()
		{
			_javaPaths = new Dictionary<JavaVersion, string>();
			try
			{
				RegistryKey javaroot = Registry.LocalMachine.OpenSubKey("SOFTWARE\\JavaSoft");
				if (Share.Is64Bit)
				{
					RegistryKey javaroot32 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\JavaSoft");
					DetectJavaFromRegistry(javaroot, true);
					DetectJavaFromRegistry(javaroot32);
				}
				else
				{
					DetectJavaFromRegistry(javaroot);
				}
			}
			catch (Exception)
			{
				Logger.Log(LogLevel.Warning, "JavaApi", "Failed to detect java from registry, falling back to filesystem");
				DetectJavaByFilestructure();
			}

			_initialized = true;
		}

		private static void DetectJavaFromRegistry(RegistryKey rootkey, bool is64Bit = false)
		{
			RegistryKey javaJre = rootkey.OpenSubKey("Java Runtime Environment");
			RegistryKey javaJdk = rootkey.OpenSubKey("Java Development Kit");

			foreach (RegistryKey versionRoot in new[] {javaJre, javaJdk})
			{
				if (versionRoot == null || versionRoot.GetSubKeyNames().Length < 1) continue; // no keys in here

				foreach (string subkey in versionRoot.GetSubKeyNames())
				{
					Match r = Regex.Match(subkey, @"^\d.(\d)$");
					if (r.Success)
					{
						int runtimeversion = Convert.ToInt32(r.Groups[1].Value);
						RegistryKey subKeyInstance = versionRoot.OpenSubKey(subkey);
						if (subKeyInstance != null)
						{
							if (string.IsNullOrEmpty(subKeyInstance.GetValue("JavaHome").ToString())) continue;
							string path = subKeyInstance.GetValue("JavaHome") + "\\bin\\java.exe";
							SetJavaPath(runtimeversion, is64Bit, path);
						}
					}
				}
			}
		}


		private static void DetectJavaByFilestructure()
		{
			if (Directory.Exists(ProgramFilesx86() + "\\Java\\"))
			{
				foreach (string dir in Directory.GetDirectories(ProgramFilesx86() + "\\Java\\"))
				{
					if ((dir.Contains("jre6") || dir.Contains("jre1.6")) && File.Exists(dir + "\\bin\\java.exe"))
						SetJavaPath(6, false, dir + "\\bin\\java.exe");
					if ((dir.Contains("jre7") || dir.Contains("jre1.7")) && File.Exists(dir + "\\bin\\java.exe"))
						SetJavaPath(7, false, dir + "\\bin\\java.exe");
					if ((dir.Contains("jre8") || dir.Contains("jre1.8")) && File.Exists(dir + "\\bin\\java.exe"))
						SetJavaPath(8, false, dir + "\\bin\\java.exe");
				}
			}

			if (Directory.Exists(ProgramFiles() + "\\Java\\") & Share.Is64Bit)
			{
				foreach (string dir in Directory.GetDirectories(ProgramFiles() + "\\Java\\"))
				{
					if ((dir.Contains("jre6") || dir.Contains("jre1.6")) && File.Exists(dir + "\\bin\\java.exe"))
						SetJavaPath(6, true, dir + "\\bin\\java.exe");
					if ((dir.Contains("jre7") || dir.Contains("jre1.7")) && File.Exists(dir + "\\bin\\java.exe"))
						SetJavaPath(7, true, dir + "\\bin\\java.exe");
					if ((dir.Contains("jre8") || dir.Contains("jre1.8")) && File.Exists(dir + "\\bin\\java.exe"))
						SetJavaPath(8, true, dir + "\\bin\\java.exe");
				}
			}
		}

		/// <summary>
		///     Set the java path for a given version
		/// </summary>
		/// <param name="version">the runtime version, between 6 and 9</param>
		/// <param name="is64Bitversion">wether or not this is a 64bit java executable</param>
		/// <param name="path">The path to java.exe. If this file does not exist, the path will not be set</param>
		private static void SetJavaPath(int version, bool is64Bitversion, string path)
		{
			if (!File.Exists(path)) return;
			int id = version*100 + ((is64Bitversion) ? 64 : 32);
			_javaPaths[(JavaVersion) id] = path;
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
			return _javaPaths.ContainsKey(jreVersion);
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

			if (jreVersion == JavaVersion.Custom)
			{
				string path = Config.ReadString("starter", "java_custom", "");
				if (string.IsNullOrEmpty(path))
				{
					OpenFileDialog ofd = new OpenFileDialog
					{
						Title = "Select java.exe",
						Filter = "Java executables (*.exe) |*.exe|All Files (*.*)|*.*"
					};
					ofd.ShowDialog();
					path = ofd.FileName;
					Config.WriteString("starter", "java_custom", path);
				}
				return path;
			}

			if (_javaPaths.ContainsKey(jreVersion)) return _javaPaths[jreVersion];
			return null;
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
		Jre6X32 = 632,

		Jre6X64 = 664,

		Jre7X32 = 732,

		Jre7X64 = 764,

		Jre8X32 = 832,

		Jre8X64 = 864,

		Jre9X32 = 932,

		Jre9X64 = 964,

		Custom
	}
}