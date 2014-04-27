namespace Net.Bertware.Bukkitgui2.AddOn.Plugins.BukgetPlugins
{
    using System;
    using System.Collections.Generic;

    using global::Bukkitgui2.AddOn.Plugins.BukgetPlugins;

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
        public DateTime ReleaseDate { get; set; }

        public string DownloadLink { get; private set; }

        public string PageLink { get; set; }

        public string VersionNumber { get; private set; }

        public List<string> CompatibleBuilds { get; set; }

        public string Filename { get; set; }

        public PluginStatus Type { get; set; }

        public string PluginName { get; private set; }

        public BukgetPluginVersion(string versionNumber, string downloadLink, string pluginName, string fileName = "")
        {
            this.Filename = fileName;
            this.PluginName = pluginName;
            this.DownloadLink = downloadLink;
            this.VersionNumber = versionNumber;

            this.CompatibleBuilds = new List<string>();
            this.Type = PluginStatus.Normal;
            this.ReleaseDate = new DateTime();
        }
    }
}