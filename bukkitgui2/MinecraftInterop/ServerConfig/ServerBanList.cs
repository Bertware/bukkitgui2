// ServerConfig.cs in bukkitgui2/bukkitgui2
// Created 2014/08/27
// Last edited at 2014/08/27 14:59
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.IO;
using Jayrock.Json;
using Jayrock.Json.Conversion;
using Net.Bertware.Bukkitgui2.Core.FileLocation;

namespace Net.Bertware.Bukkitgui2.MinecraftInterop.ServerConfig
{
	public static class ServerBanlist
	{
		private static bool _initialized;
		private static string _lastPath;
		private static Dictionary<string, ServerListItem> _bans;

		public static void Initialize()
		{
			LoadList(Fl.SafeLocation(RequestFile.Serverdir) + "\\banned-players.json");
			_initialized = true;
		}

		public static Dictionary<string, ServerListItem> BanList
		{
			get
			{
				if (!_initialized) Initialize();
				return _bans;
			}
		}

		/// <summary>
		///     Load a server.properties file
		/// </summary>
		/// <param name="path">the full path to the file</param>
		public static void LoadList(string path)
		{
			_lastPath = path;

			_bans = new Dictionary<string, ServerListItem>();
			if (!File.Exists(path)) return;

			string jsonText = File.ReadAllText(path);
			JsonArray array = JsonConvert.Import<JsonArray>(jsonText);
			foreach (JsonObject obj in array)
			{
				ServerListItem item = new ServerListItem(obj);
				if (!_bans.ContainsKey(item.Name)) _bans.Add(item.Name, item);
			}
		}
		/// <summary>
		/// Set a list entry
		/// </summary>
		/// <param name="name">The name of the player, of which you want to set the entry</param>
		/// <param name="value">The value you want to assign to this setting</param>
		/// <returns></returns>
		public static void SetListEntry(string name, ServerListItem value)
		{
			// if not yet initialized, initialize
			if (!_initialized) Initialize();

			if (_bans.ContainsKey(name))
			{
				_bans[name] = value;
			}
			else
			{
				_bans.Add(name, value);
			}
		}
		/// <summary>
		/// Get an entry in the list
		/// </summary>
		/// <param name="name">The name of the player, of which you want to retrieve the entry</param>
		/// <returns></returns>
		public static ServerListItem GetListEntry(string name)
		{
			// if not yet initialized, initialize
			if (_bans.ContainsKey(name))
				return _bans[name];
			return null;
		}

		/// <summary>
		/// Save the server settings
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