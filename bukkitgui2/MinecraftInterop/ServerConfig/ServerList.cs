// ServerList.cs in bukkitgui2/bukkitgui2
// Created 2014/08/29
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.IO;
using Jayrock.Json;
using Jayrock.Json.Conversion;
using Net.Bertware.Bukkitgui2.Core.FileLocation;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.Core.Util;

namespace Net.Bertware.Bukkitgui2.MinecraftInterop.ServerConfig
{
	/// <summary>
	///     This class allows to read a list (whitelist, banned players/ip's, op's) and has static access to each list.
	///     Use the static serverlists to get a list for the current server.
	/// </summary>
	public class ServerList
	{
		private static ServerList _ops;

		public static ServerList Ops
		{
			get
			{
				if (!_initialized) InitializeAllLists();
				return _ops;
			}
		}

		private static ServerList _whiteList;

		public static ServerList WhiteList
		{
			get
			{
				if (!_initialized) InitializeAllLists();
				return _whiteList;
			}
		}

		private static ServerList _bannedPlayers;

		public static ServerList BannedPlayers
		{
			get
			{
				if (!_initialized) InitializeAllLists();
				return _bannedPlayers;
			}
		}

		private static ServerList _bannedIps;

		public static ServerList BannedIps
		{
			get
			{
				if (!_initialized) InitializeAllLists();
				return _bannedIps;
			}
		}

		private static bool _initialized;

		private readonly ServerListType _type;

		private string _path;
		private FileSystemWatcher _watcher;

		public static void InitializeAllLists()
		{
			// don't initialize twice
			if (_initialized) return;
			try
			{
				_ops = new ServerList(ServerListType.Ops);
				_whiteList = new ServerList(ServerListType.Whitelist);
				_bannedPlayers = new ServerList(ServerListType.Banned_Players);
				_bannedIps = new ServerList(ServerListType.Banned_Ips);
				_initialized = true;
			}
			catch (Exception exception)
			{
				Logger.Log(LogLevel.Warning, "ServerList", "Couldn't initialize!", exception.Message);
			}
		}

		private ServerList(ServerListType type)
		{
			_type = type;
			Initialize();
		}

		/// <summary>
		///     Event which is raised when the list has been altered
		/// </summary>
		public event EventHandler ListUpdated;

		private void OnListUpdated()
		{
			EventHandler handler = ListUpdated;
			if (handler != null) handler(null, EventArgs.Empty);
		}

		private void Initialize()
		{
			try
			{
				string file = _type.ToString().ToLower().Replace('_', '-') + ".json";
				_path = Fl.SafeLocation(RequestFile.Serverdir) + file;

				LoadList();
				_watcher = new FileSystemWatcher(Fl.SafeLocation(RequestFile.Serverdir))
				{
					Filter = "*" + file,
					NotifyFilter = NotifyFilters.Size | NotifyFilters.LastWrite,
					EnableRaisingEvents = true
				};
				_watcher.Changed += ((sender, e) => LoadList());
			}
			catch (Exception exception)
			{
				Logger.Log(LogLevel.Warning, "ServerList", "Couldn't initialize " + _type, exception.Message);
			}
		}

		public Dictionary<string, ServerListItem> List { get; private set; }

		/// <summary>
		///     Load a json list file
		/// </summary>
		private void LoadList()
		{
			List = new Dictionary<string, ServerListItem>();
			if (!File.Exists(_path)) return;

			try
			{
				string jsonText = FsUtil.ReadFileInUse(_path);
				if (string.IsNullOrEmpty(jsonText)) return;

				JsonArray array = JsonConvert.Import<JsonArray>(jsonText);
				foreach (JsonObject obj in array)
				{
					ServerListItem item = new ServerListItem(obj);
					if (string.IsNullOrEmpty(item.Name)) continue;
					if (!List.ContainsKey(item.Name)) List.Add(item.Name, item);
				}
				OnListUpdated();
			}
			catch (Exception ex)
			{
				Logger.Log(LogLevel.Warning, "Failed to load list: " + _type, ex.Message);
			}
		}
	}

	public enum ServerListType
	{
		Ops,
		Whitelist,
		Banned_Players,
		Banned_Ips
	}
}