// VanillaDownloadProvider.cs in bukkitgui2/bukkitgui2
// Created 2014/12/25
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
// ReSharper disable InconsistentNaming

namespace Net.Bertware.Bukkitgui2.MinecraftServers.Tools.Vanilla
{
	public static class VanillaDownloadProvider
	{
		public static string GetLatestUrl()
		{
            try
            {
                VanillaDownload download = GetDownloadFromId(
                    GetLatestVersion(),
                    VanillaDownloadType.snapshot);
                return GetVanillaDownloadURL(download);
            }
            catch (Exception e)
            {
                Logger.Log(LogLevel.Warning, "VanillaDownloadProvider",
                    "Failed to retrieve latest vanilla version URL", e.Message);

                // Why isn't this string null or empty?
                // If address has invalid format, WebUtil crashes BukkitGui
                // This is a little workarround
                // https://0.0.0.0 leads to "void", but it doesn't crash BG
                return "https://0.0.0.0";
            }
		}

		public static string GetLatestRecommendedVersionUrl()
		{
            try
            {
                VanillaDownload download = GetDownloadFromId(
                    GetLatestVersion(),
                    VanillaDownloadType.release);
                return GetVanillaDownloadURL(download);
            }
            catch (Exception e)
            {
                Logger.Log(LogLevel.Warning, "VanillaDownloadProvider",
                    "Failed to retrieve latest recommended vanilla version URL", e.Message);

                // Why isn't this string null or empty?
                // If address has invalid format, WebUtil crashes BukkitGui
                // This is a little workarround
                // https://0.0.0.0 leads to "void", but it doesn't crash BG
                return "https://0.0.0.0";
            }
        }

        private static VanillaDownload GetDownloadFromId(string id, VanillaDownloadType type)
        {
            try
            {
                VanillaDownload result = null;

                string latestId = GetLatestVersionId(type);

                foreach (VanillaDownload download in GetVersionInfo().Versions)
                {
                    if (download.Id == latestId)
                    {
                        result = download;
                        break;
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                Logger.Log(LogLevel.Warning, "VanillaDownloadProvider", "Failed to retrieve download from ID",
                    e.Message);
                return null;
            }
        }

        private static string GetVanillaDownloadURL(VanillaDownload download)
        {
            string json = WebUtil.RetrieveString(download.URL);

            if (string.IsNullOrEmpty(json)) return null;

            //{
            //  "downloads": {
            //    "client": {
            //      "sha1": "3ad1375091d9de67beb3197dcd173d05ff27dd0b",
            //      "size": 16089525,
            //      "url": "https:\/\/launcher.mojang.com\/v1\/objects\/3ad1375091d9de67beb3197dcd173d05ff27dd0b\/client.jar"
            //    },
            //    "server": {
            //      "sha1": "2f39df32f20196b5a6acad117f7d6b404b069c58",
            //      "size": 33834968,
            //      "url": "https:\/\/launcher.mojang.com\/v1\/objects\/2f39df32f20196b5a6acad117f7d6b404b069c58\/server.jar"
            //    }
            //  }
            //}

            // Root level
            JsonObject obj = JsonConvert.Import<JsonObject>(json);
            string temp = obj["downloads"].ToString();
            // 'downloads' level
            obj = JsonConvert.Import<JsonObject>(temp);
            temp = obj["server"].ToString();
            // 'server' level
            obj = JsonConvert.Import<JsonObject>(temp);
            return obj["url"].ToString();
        }

        private static string GetLatestVersionId(VanillaDownloadType type)
        {
            try
            {
                JsonObject latestList = JsonConvert.Import<JsonObject>(GetVersionInfo().Latest);

                if (type == VanillaDownloadType.unknown)
                    return null;

                return latestList[type.ToString()].ToString();
            }
            catch (Exception e)
            {
                Logger.Log(LogLevel.Warning, "VanillaDownloadProvider",
                    "Failed to retrieve latest vanilla version ID", e.Message);
                return "";
            }
        }

		public static string GetLatestVersion()
		{
			try
			{
                return GetLatestVersionId(VanillaDownloadType.snapshot);
            }
			catch (Exception e)
			{
				Logger.Log(LogLevel.Warning, "VanillaDownloadProvider", "Failed to retrieve latest  vanilla version",
					e.Message);
				return "";
			}
		}

		public static string GetLatestRecommendedVersion()
		{
			try
			{
				foreach (VanillaDownload version in GetVersionInfo().Versions)
				{
					if (version.Type == VanillaDownloadType.release) return version.Id;
				}
				return GetLatestVersion();
			}
			catch (Exception e)
			{
				Logger.Log(LogLevel.Warning, "VanillaDownloadProvider",
					"Failed to retrieve latest recommended vanilla version", e.Message);
				return "";
			}
		}

        private static VanillaDownloadInfo _cache;

		private static VanillaDownloadInfo GetVersionInfo()
		{
			try
			{
				if (_cache != null) return _cache;
				string json =
					WebUtil.RetrieveString("https://launchermeta.mojang.com/mc/game/version_manifest.json");
				if (string.IsNullOrEmpty(json)) return null;
				_cache = new VanillaDownloadInfo(json);
				return _cache;
			}
			catch (Exception e)
			{
				Logger.Log(LogLevel.Warning, "VanillaDownloadProvider", "Failed to retrieve vanilla download info",
					e.Message);
				return null;
			}
		}
	}

	internal class VanillaDownloadInfo
	{
		public List<VanillaDownload> Versions { get; private set; }
		public string Latest { get; private set; }

		public VanillaDownloadInfo(string json)
		{
			JsonObject obj = JsonConvert.Import<JsonObject>(json);


			try
			{
				Versions = new List<VanillaDownload>();
				Latest = obj["latest"].ToString();

				foreach (JsonObject entry in (JsonArray) obj["versions"])
				{
					Versions.Add(new VanillaDownload(entry.ToString()));
				}
			}
			catch (Exception e)
			{
				Logger.Log(LogLevel.Warning, "VanillaDownloadProvider", "Failed to parse downloadInfo", e.Message);
			}
		}
	}

	internal class VanillaDownload
    {
        //{
        //  "id": "1.13.2-pre2",
        //  "type": "snapshot",
        //  "url": "https:\/\/launchermeta.mojang.com\/v1\/packages\/d62148cdd47d2e7e524ea027bf01d5f74f26a020\/1.13.2-pre2.json",
        //  "time": "2018-10-18T14:48:25+00:00",
        //  "releaseTime": "2018-10-18T14:46:12+00:00"
        //},
		public String Id { get; private set; }
		public DateTime Time { get; private set; }

		public DateTime ReleaseTime { get; private set; }

		public VanillaDownloadType Type { get; private set; }

        public string URL;

		public VanillaDownload(string json)
		{
			JsonObject obj = JsonConvert.Import<JsonObject>(json);
			if (obj.Contains("id"))
			{
				Id = obj["id"].ToString();
			}
			else
			{
				if (obj.Contains("snapshot")) Id = obj["snapshot"].ToString();
			}

			try
			{
				if (obj.Contains("time")) Time = DateTime.Parse(obj["time"].ToString());
				if (obj.Contains("releasetime")) ReleaseTime = DateTime.Parse(obj["releasetime"].ToString());
				if (obj.Contains("type"))
					Type = (VanillaDownloadType) Enum.Parse(typeof (VanillaDownloadType), obj["type"].ToString());
                if (obj.Contains("url"))
                    URL = obj["url"].ToString();
            }
			catch (Exception e)
			{
				Logger.Log(LogLevel.Warning, "VanillaDownloadProvider", "Failed to parse download", e.Message);
			}
		}
	}

	internal enum VanillaDownloadType
	{
		// these names HAVE to be exact!
		snapshot,
		release,
		unknown
	}
}