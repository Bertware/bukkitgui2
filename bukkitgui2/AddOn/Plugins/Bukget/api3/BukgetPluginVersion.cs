// BukgetPluginVersion.cs in bukkitgui2/bukkitgui2
// Created 2014/05/03
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using Jayrock.Json;
using Jayrock.Json.Conversion;

namespace Net.Bertware.Bukkitgui2.AddOn.Plugins.Bukget.api3
{
	/// <summary>
	///     Contains details of a plugin version, including all data needed to update or install a plugin
	/// </summary>
	/// <remarks></remarks>
	public class BukgetPluginVersion
	{
		// "date": 1317404619,
		// "dl_link": "http://dev.bukkit.org/media/files/LINK_TO_JAR/ZIP",
		// "filename": "AcceptRules.jar",
		// "game_builds": ["1000", "9999", "CB-1.7.2"],
		// "hard_dependencies": [],
		// "md5": "8184a10ef2657024ca0ceb38f9b681eb",
		// "name": "v0.7",
		// "soft_dependencies": []

		public BukgetPlugin Plugin { get; set; }

		public DateTime ReleaseDate { get; set; }

		public string DownloadLink { get; set; }

		public string PageLink { get; set; }

		public string VersionNumber { get; private set; }

		public List<string> CompatibleBuilds { get; set; }

		public string Filename { get; set; }

		public PluginStatus Type { get; set; }

		public string PluginName
		{
			get { return Plugin.Name; }
		}

		public BukgetPluginVersion(BukgetPlugin plugin, String jsonCode)
		{
			{
				InitFields();
				//create JSON object
				JsonObject json = (JsonObject) JsonConvert.Import(jsonCode);

				Plugin = plugin;

				if (json["version"] == null)
				{
					VersionNumber = null;
					return;
				}

				VersionNumber = json["version"].ToString();

				{
					CompatibleBuilds =
						JsonParser.ParseJsonStringList(
							json["game_versions"]);
				}


			
				if (json["download"] != null)
				{
					// BukkitDev Compliancy
					// Since this program is distributed using dev.bukkit.org, every download url needs to have the "http://dev.bukkit.org" part hardcoded
					
					DownloadLink = json["download"].ToString();
					if (DownloadLink.StartsWith("http://") || DownloadLink.StartsWith("https://"))
					{
						DownloadLink = DownloadLink.Substring(DownloadLink.IndexOf('/', 10));
						DownloadLink = "http://dev.bukkit.org/" + DownloadLink;
					}
				}
			
				
				if (json["link"] != null) PageLink = json["link"].ToString();

				
				if (json["date"] != null)
					ReleaseDate = new DateTime(1970, 1, 1).AddSeconds(Convert.ToDouble(json["date"].ToString()));

				
				if (json["filename"] != null) Filename = json["filename"].ToString();

			
				if (json["status"] != null)
					Type = (PluginStatus) Enum.Parse(typeof (PluginStatus), json["status"].ToString().Replace("-", "_"));
			}
		}

		/// <summary>
		///     Initialize this version object with default values
		/// </summary>
		private void InitFields()
		{
			Plugin = null;
			ReleaseDate = new DateTime();
			DownloadLink = "";
			PageLink = "";
			VersionNumber = "";
			CompatibleBuilds = new List<string>();
			Filename = "";
			Type = PluginStatus.Normal;
		}

		public Boolean Install(string targetLocation = "")
		{
			return BukgetPluginInstaller.Install(this, targetLocation, true,true);
		}
	}
}