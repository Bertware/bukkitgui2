// ServerWhitelist.cs in bukkitgui2/bukkitgui2
// Created 2014/08/28
// Last edited at 2014/08/29 12:58
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.IO;
using Jayrock.Json;
using Jayrock.Json.Conversion;
using Net.Bertware.Bukkitgui2.Core.FileLocation;
using Net.Bertware.Bukkitgui2.Core.Logging;

namespace Net.Bertware.Bukkitgui2.MinecraftInterop.ServerConfig
{
	public static class ServerWhitelist
	{
		private static bool _initialized;
		private static string _lastPath;
		private static Dictionary<string, ServerListItem> _whitelist;

		public static void Initialize()
		{
			LoadList(Fl.SafeLocation(RequestFile.Serverdir) + "\\whitelist.json");
			_initialized = true;
		}

		public static Dictionary<string, ServerListItem> Whitelist
		{
			get
			{
				if (!_initialized) Initialize();
				return _whitelist;
			}
		}

		/// <summary>
		///     Load a server.properties file
		/// </summary>
		/// <param name="path">the full path to the file</param>
		public static void LoadList(string path)
		{
			try
			{
				_lastPath = path;

				_whitelist = new Dictionary<string, ServerListItem>();
				if (!File.Exists(path)) return;

				string jsonText = File.ReadAllText(path);
				JsonArray array = (JsonArray) JsonConvert.Import(jsonText);
				foreach (JsonObject obj in array)
				{
					ServerListItem item = new ServerListItem(obj);
					if (string.IsNullOrEmpty(item.Name)) continue;
					if (!_whitelist.ContainsKey(item.Name)) _whitelist.Add(item.Name, item);
				}
			}
			catch (Exception ex)
			{
				Logger.Log(LogLevel.Warning, "ServerWhitelist", "Failed to load list: " + path, ex.Message);
			}
		}

		/// <summary>
		///     Set a list entry
		/// </summary>
		/// <param name="name">The name of the player, of which you want to set the entry</param>
		/// <param name="value">The value you want to assign to this setting</param>
		/// <returns></returns>
		public static void SetListEntry(string name, ServerListItem value)
		{
			// if not yet initialized, initialize
			if (!_initialized) Initialize();

			if (_whitelist.ContainsKey(name))
			{
				_whitelist[name] = value;
			}
			else
			{
				_whitelist.Add(name, value);
			}
		}

		/// <summary>
		///     Get an entry in the list
		/// </summary>
		/// <param name="name">The name of the player, of which you want to retrieve the entry</param>
		/// <returns></returns>
		public static ServerListItem GetListEntry(string name)
		{
			// if not yet initialized, initialize
			if (_whitelist.ContainsKey(name))
				return _whitelist[name];
			return null;
		}


		/// <summary>
		///     Get an entry in the list
		/// </summary>
		/// <param name="name">The name of the player, of which you want to retrieve the entry</param>
		/// <returns></returns>
		public static void RemoveListEntry(string name)
		{
			// if not yet initialized, initialize
			if (_whitelist.ContainsKey(name))
				_whitelist.Remove(name);
		}


		/// <summary>
		///     Save the server settings
		/// </summary>
		/// <param name="path">The path to save the file to. If empty, the last loaded file will be overwritten</param>
		public static void SaveList(string path = "")
		{
			if (string.IsNullOrEmpty(path)) path = _lastPath;

			//TODO: save file
			throw new NotImplementedException();
		}
	}
}