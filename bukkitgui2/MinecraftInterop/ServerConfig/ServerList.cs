// ServerList.cs in bukkitgui2/bukkitgui2
// Created 2014/08/29
// Last edited at 2014/08/30 13:57
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
		private Dictionary<string, ServerListItem> _list;
		private FileSystemWatcher _watcher;

		public static void InitializeAllLists()
		{
			// don't initialize twice
			if (_initialized) return;
			_ops = new ServerList(ServerListType.Ops);
			_whiteList = new ServerList(ServerListType.Whitelist);
			_bannedPlayers = new ServerList(ServerListType.Banned_Players);
			_bannedIps = new ServerList(ServerListType.Banned_Ips);
			_initialized = true;
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
			string file = _type.ToString().ToLower().Replace('_', '-') + ".json";
			_path = Fl.SafeLocation(RequestFile.Serverdir)  + file;

			LoadList();
			_watcher = new FileSystemWatcher(Fl.SafeLocation(RequestFile.Serverdir))
			{
				Filter = "*" + file,
				NotifyFilter = NotifyFilters.Size | NotifyFilters.LastWrite,
				EnableRaisingEvents = true
			};
			_watcher.Changed += ((sender, e) => LoadList());
		}

		public Dictionary<string, ServerListItem> List
		{
			get { return _list; }
		}

		/// <summary>
		///     Load a json list file
		/// </summary>
		private void LoadList()
		{
			_list = new Dictionary<string, ServerListItem>();
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
					if (!_list.ContainsKey(item.Name)) _list.Add(item.Name, item);
				}
				OnListUpdated();
			}
			catch (Exception ex)
			{
				Logger.Log(LogLevel.Warning, "Failed to load list: " + _type,ex.Message);
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