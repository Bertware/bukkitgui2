// BukgetPlugin.cs in bukkitgui2/bukkitgui2
// Created 2014/05/03
// Last edited at 2014/05/24 12:16
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using Jayrock.Json;
using Jayrock.Json.Conversion;
using Net.Bertware.Bukkitgui2.Core.Logging;

namespace Net.Bertware.Bukkitgui2.AddOn.Plugins.Bukget.api3
{
	/// <summary>
	///     Most detailled plugin class for installing plugins and showing info
	/// </summary>
	/// <remarks></remarks>
	public class BukgetPlugin
	{
		/// <summary>
		///     The name of this plugin
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		///     The description of this plugin
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		///     The main namespace this plugin
		/// </summary>
		public string Main { get; private set; }

		/// <summary>
		///     The slug of this plugin
		/// </summary>
		public string Slug { get; set; }

		/// <summary>
		///     The authors of the plugin
		/// </summary>
		public List<string> AuthorsList { get; set; }

		/// <summary>
		///     The versions of the plugin
		/// </summary>
		public List<PluginCategory> CategoryList { get; set; }

		/// <summary>
		///     The status of the plugin
		/// </summary>
		public PluginStatus Status { get; set; }

		/// <summary>
		///     The versions of the plugin
		/// </summary>
		public List<BukgetPluginVersion> VersionsList { get; set; }

		/// <summary>
		///     The bukkitdev link of the plugin
		/// </summary>
		public string BukkitDevLink { get; set; }

		/// <summary>
		///     Get the last available version for this plugin
		/// </summary>
		public BukgetPluginVersion LastVersion
		{
			get
			{
				if (VersionsList == null || VersionsList.Count < 1) return null;
				return VersionsList[0];
			}
		}

		/// <summary>
		///     Get the last supported game version
		/// </summary>
		public String LastGameVersion
		{
			get
			{
				BukgetPluginVersion version = LastVersion;
				if (version == null || version.CompatibleBuilds.Count < 1) return "";
				return version.CompatibleBuilds[0];
			}
		}

		/// <summary>
		///     Get the last version number
		/// </summary>
		public String LastVersionNumber
		{
			get
			{
				BukgetPluginVersion version = LastVersion;
				if (version == null || string.IsNullOrEmpty(version.VersionNumber)) return "";
				return version.CompatibleBuilds[0];
			}
		}

		/// <summary>
		///     The website of the plugin
		/// </summary>
		public string Website { get; set; }

		public BukgetPlugin(string main, string name)
		{
			InitFields();
			Main = main;
			Name = name;
		}

		/// <summary>
		///     Parse a bukget plugin from the json result
		/// </summary>
		/// <param name="jsonCode"></param>
		/// <returns></returns>
		public BukgetPlugin(string jsonCode)
		{
			InitFields();

			// Load the string into a json object
			JsonObject json;
			// In case of an array, load the first entry
			if (jsonCode.StartsWith("["))
			{
				json = (JsonObject) JsonConvert.Import<JsonArray>(jsonCode)[0];
			}
			else
			{
				json = JsonConvert.Import<JsonObject>(jsonCode);
			}

			string main = null;
			if (json["main"] != null) main = (string) json["main"];

			string pluginName = null;
			if (json["plugin_name"] != null) pluginName = (string) json["plugin_name"];

			// If no name or mainspace, return
			if (string.IsNullOrEmpty(main) || string.IsNullOrEmpty(pluginName)) return;

			Logger.Log(LogLevel.Info, "BukGetAPI", "parsing plugin:" + pluginName, main);

			// Slug
			if (json["slug"] != null) Slug = (String) json["slug"];
			// Description
			if (json["description"] != null) Description = (String) json["description"];
			// BukkitDev link
			if (json["dbo_page"] != null) BukkitDevLink = (String) json["dbo_page"];
			// Website
			if (json["link"] != null) Website = (String) json["link"];
			// Stage
			if (json["stage"] != null)
			{
				try
				{
					Status = (PluginStatus) Enum.Parse(typeof (PluginStatus), json["stage"].ToString());
				}
				catch (Exception e)
				{
					Logger.Log(LogLevel.Warning, "BukgetV3", "Couldn't parse plugin status", e.Message);
				}
			}
			// Authors
			AuthorsList = JsonParser.ParseJsonStringList(json["authors"]);

			// Categories
			// load strings
			List<String> categories = JsonParser.ParseJsonStringList(json["categories"]);
			// convert to enum values
			foreach (string category in categories)
			{
				CategoryList.Add((PluginCategory) Enum.Parse(typeof (PluginCategory), category));
			}

			// Versions
			IEnumerable<JsonObject> versions = JsonParser.ParseJsonObjectList(json["versions"]);
			foreach (JsonObject jsonObject in versions)
			{
				BukgetPluginVersion v = new BukgetPluginVersion(this, jsonObject.ToString());
				if (v.VersionNumber != null) VersionsList.Add(v);
			}
		}

		/// <summary>
		///     Set default values for all fields
		/// </summary>
		private void InitFields()
		{
			Main = null;
			Name = null;
			Description = "";
			AuthorsList = new List<string>();
			VersionsList = new List<BukgetPluginVersion>();
			CategoryList = new List<PluginCategory>();
			Status = PluginStatus.Normal;
			BukkitDevLink = "";
			Website = "";
		}
	}
}