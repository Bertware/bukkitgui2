// BukgetPlugin.cs in bukkitgui2/bukkitgui2
// Created 2014/05/03
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using Jayrock.Json;
using Jayrock.Json.Conversion;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.Core.Util.Web;

namespace Net.Bertware.Bukkitgui2.AddOn.Plugins.Bukget.api3
{
    /// <summary>
    ///     Most detailled plugin class for installing plugins and showing info
    /// </summary>
    /// <remarks></remarks>
    public class BukgetPlugin
    {
        /// <summary>
        ///     The last parsed plugin, cache
        /// </summary>
        public static BukgetPlugin LastParsedPlugin { get; private set; }

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
                return version.VersionNumber;
            }
        }

        /// <summary>
        ///     The website of the plugin
        /// </summary>
        public string Website { get; set; }

        /// <summary>
        ///     Show a dialog with plugin info & versions
        /// </summary>
        public void ShowVersionDialog(string currentPluginVersionPath = "")
        {
            BukgetPluginView pluginView = new BukgetPluginView
            {
                Plugin = this,
                CurrentPluginVersionPath = currentPluginVersionPath
            };
            pluginView.ShowDialog();
        }

        /// <summary>
        ///     Install the latest plugin version
        /// </summary>
        public void InstallLatestVersion(string targetlocation = "")
        {
            LastVersion.Install(targetlocation);
        }

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
			if (string.IsNullOrEmpty(jsonCode)) throw new FormatException("Invalid JSON supplied: string is empty");

			if (Equals(jsonCode, "[]")) throw new FormatException("Invalid JSON supplied: array is empty");
            // Load the string into a json object
            JsonObject json;
            // In case of an array, load the first entry
	        try
	        {
		        if (jsonCode.StartsWith("["))
		        {
			        json = (JsonObject) JsonConvert.Import<JsonArray>(jsonCode)[0];
		        }
		        else
		        {
			        json = JsonConvert.Import<JsonObject>(jsonCode);
		        }

	        }
	        catch (Exception exception)
	        {
				throw new FormatException("Invalid JSON supplied: " + exception);
	        }
		
            if (json["main"] != null) Main = (string) json["main"];


            if (json["plugin_name"] != null) Name = (string) json["plugin_name"];

            // If no name or mainspace, return
            if (string.IsNullOrEmpty(Main) || string.IsNullOrEmpty(Name)) return;

            Logger.Log(LogLevel.Info, "BukGetAPI", "parsing plugin:" + Name, Main);

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
            LastParsedPlugin = this;
        }

        public static List<BukgetPlugin> ParsePluginList(string json)
        {
            List<BukgetPlugin> result = new List<BukgetPlugin>();

            if (json.StartsWith("["))
            {
                JsonArray jsonArray = JsonConvert.Import<JsonArray>(json);
                foreach (JsonObject jsonObject in jsonArray)
                {
                    BukgetPlugin plugin = new BukgetPlugin(jsonObject.ToString());
                    if (string.IsNullOrEmpty(plugin.Main) || string.IsNullOrEmpty(plugin.Name)) continue;
                    result.Add(plugin);
                }
            }
            else
            {
                result.Add(new BukgetPlugin(json));
            }


            return result;
        }

        /// <summary>
        ///     Create a plugin object based upon it's name and web data
        /// </summary>
        /// <param name="name">the name of the plugin to search/create</param>
        /// <returns></returns>
        public static BukgetPlugin CreateFromName(string name)
        {
            string url = BukgetUrlBuilder.ConstructUrl(PluginInfoField.Plugin_Name, SearchAction.Equals, name, 1);
            string data = WebUtil.RetrieveString(url);
            return new BukgetPlugin(data);
        }

        /// <summary>
        ///     Create a plugin object based upon it's main namespace and web data
        /// </summary>
        /// <param name="main">the main namespace of the plugin to search/create</param>
        /// <returns></returns>
        public static BukgetPlugin CreateFromNamespace(string main)
        {
            string url = BukgetUrlBuilder.ConstructUrl(PluginInfoField.Main, SearchAction.Equals, main, 1);
            string data = WebUtil.RetrieveString(url);
            return new BukgetPlugin(data);
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Main)) return "Invalid plugin!";
            return "BukgetPlugin." + Name + "@" + Main;
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