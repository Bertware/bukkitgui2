using System;
using System.Collections.Generic;
using Jayrock.Json;
using Jayrock.Json.Conversion;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.Core.Util.Web;

namespace Net.Bertware.Bukkitgui2.MinecraftServers.Tools.Vanilla
{
    public static class VanillaDownloadProvider
    {
        public static string GetLatestUrl()
        {
            string id = GetLatestVersion();
            return "https://s3.amazonaws.com/Minecraft.Download/versions/" + id + "/minecraft_server." + id + ".jar";
        }

        public static string GetLatestRecommendedVersionUrl()
        {
            string id = GetLatestRecommendedVersion();
            return "https://s3.amazonaws.com/Minecraft.Download/versions/" + id + "/minecraft_server." + id + ".jar";
        }

        public static string GetLatestVersion()
        {
            try
            {
                return GetVersionInfo().Latest.Id;
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
                    WebUtil.RetrieveString("https://s3.amazonaws.com/Minecraft.Download/versions/versions.json");
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
        public VanillaDownload Latest { get; private set; }

        public VanillaDownloadInfo(string json)
        {
            JsonObject obj = JsonConvert.Import<JsonObject>(json);


            try
            {
                Versions = new List<VanillaDownload>();
                Latest = new VanillaDownload(obj["latest"].ToString());

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
        //  "id": "1.8.1-pre4",
        //  "time": "2014-11-06T14:10:50+00:00",
        //  "releaseTime": "2014-11-06T14:10:50+00:00",
        //  "type": "snapshot"
        //},
        public String Id { get; private set; }
        public DateTime Time { get; private set; }

        public DateTime ReleaseTime { get; private set; }

        public VanillaDownloadType Type { get; private set; }

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
            }
            catch (Exception e)
            {
                Logger.Log(LogLevel.Warning, "VanillaDownloadProvider", "Failed to parse download", e.Message);
            }
        }
    }

    internal enum VanillaDownloadType
    {
        snapshot,
        release,
        old_alpha,
        old_beta,
        unknown
    }
}