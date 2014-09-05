// ServerProperties.cs in bukkitgui2/bukkitgui2
// Created 2014/08/28
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System.Collections.Generic;
using System.IO;
using Net.Bertware.Bukkitgui2.Core.FileLocation;
using Net.Bertware.Bukkitgui2.Core.Logging;

namespace Net.Bertware.Bukkitgui2.MinecraftInterop.ServerConfig
{
	internal static class ServerProperties
	{
		private static bool _initialized;
		private static string _lastPath;
		private static Dictionary<string, string> _serverSettings;

		public static void Initialize()
		{
			LoadSettings(Fl.SafeLocation(RequestFile.Serverdir) + "\\server.properties");
			_initialized = true;
		}

		public static Dictionary<string, string> ServerSettings
		{
			get
			{
				if (!_initialized) Initialize();
				return _serverSettings;
			}
		}

		/// <summary>
		///     Load a server.properties file
		/// </summary>
		/// <param name="path">the full path to the file</param>
		public static void LoadSettings(string path)
		{
			_lastPath = path;
			Logger.Log(LogLevel.Info, "ServerProperties", "Loading properties file...", path);
			_serverSettings = new Dictionary<string, string>();
			if (!File.Exists(path)) return;

			string[] lines = File.ReadAllLines(path);

			foreach (string line in lines)
			{
				if (line.StartsWith("#") || !line.Contains("=")) continue;
				string key = line.Split('=')[0];
				string value = line.Split('=')[1];
				if (!_serverSettings.ContainsKey(key)) _serverSettings.Add(key, value);
			}
			Logger.Log(LogLevel.Info, "ServerProperties", "Loaded properties file", path);
		}

		/// <summary>
		///     Set a server setting in server.properties
		/// </summary>
		/// <param name="setting">The setting to save</param>
		/// <param name="value">The value you want to assign to this setting</param>
		/// <returns></returns>
		public static void SetServerSetting(string setting, string value)
		{
			// if not yet initialized, initialize
			if (!_initialized) Initialize();

			if (_serverSettings.ContainsKey(setting))
			{
				_serverSettings[setting] = value;
			}
			else
			{
				_serverSettings.Add(setting, value);
			}
			Logger.Log(LogLevel.Info, "ServerProperties", "Updated setting", setting + " : " + value);
			SaveSettings();
		}

		/// <summary>
		///     Get a server setting from server.properties
		/// </summary>
		/// <param name="setting">The setting to retrieve</param>
		/// <returns></returns>
		public static string GetServerSetting(string setting)
		{
			// if not yet initialized, initialize
			if (_serverSettings.ContainsKey(setting))
				return _serverSettings[setting];
			return null;
		}

		/// <summary>
		///     Save the server settings
		/// </summary>
		/// <param name="path">The path to save the file to. If empty, the last loaded file will be overwritten</param>
		public static void SaveSettings(string path = "")
		{
			if (string.IsNullOrEmpty(path)) path = _lastPath;
			Logger.Log(LogLevel.Info, "ServerProperties", "Saving properties file...", path);
			string[] lines = new string[_serverSettings.Count];
			int i = 0;
			foreach (KeyValuePair<string, string> serverSetting in _serverSettings)
			{
				lines[i] = serverSetting.Key + "=" + serverSetting.Value;
				i++;
			}

			File.WriteAllLines(path, lines);
			Logger.Log(LogLevel.Info, "ServerProperties", "Saved properties file", path);
		}
	}
}