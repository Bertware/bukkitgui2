namespace Net.Bertware.Bukkitgui2.AddOn.Plugins.BukgetPlugins
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Contains details of a plugin version, including all data needed to update or install a plugin
    /// </summary>
    /// <remarks></remarks>
    public class BukgetPluginVersion
    {
        // "date": 1317404619,
        // "dl_link": "http://dev.bukkit.org/media/files/LINK_TO_JAR/ZIP",
        // "filename": "AcceptRules.jar",
        // "game_builds": ["1000", "9999"],
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
            get
            {
                return this.Plugin.Name;
            }
        }

        public BukgetPluginVersion(BukgetPlugin plugin, string versionNumber)
        {
            this.Plugin = plugin;
            this.VersionNumber = versionNumber;
            this.Filename = "";
            this.PluginName = "";
            this.DownloadLink = "";
            this.VersionNumber = versionNumber;

            this.CompatibleBuilds = new List<string>();
            this.Type = PluginStatus.Normal;
            this.ReleaseDate = new DateTime();
        }
    }
}