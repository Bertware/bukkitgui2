namespace Net.Bertware.Bukkitgui2.AddOn.Plugins.BukgetPlugins
{
    using System;
    using System.Collections.Generic;

    using Net.Bertware.Bukkitgui2.AddOn.Plugins.BukgetPlugins;

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
        ///     The website of the plugin
        /// </summary>
        public string Website { get; set; }

        public BukgetPlugin(string main, string name)
        {
            this.SetFields(main, name);
        }

        public void FromSimplePlugin(BukgetPluginListItem pluginListItem)
        {
            this.SetFields(pluginListItem.Main, pluginListItem.Name, pluginListItem.Description);
        }

        /// <summary>
        ///     Save field values for all fields (with default values)
        /// </summary>
        /// <param name="main">The main namespace this plugin</param>
        /// <param name="name">The name this plugin</param>
        /// <param name="description">The description this plugin</param>
        /// <param name="authors">The authors of the plugin</param>
        /// <param name="versions">The versions of the plugin</param>
        /// <param name="status">The status of the plugin</param>
        /// <param name="dboLink">The bukkitdev link of the plugin</param>
        /// <param name="website">The website of the plugin</param>
        /// <remarks> This method is used to prevent code duplication in the contructors </remarks>
        private void SetFields(
            string main,
            string name,
            string description = "",
            List<String> authors = null,
            List<BukgetPluginVersion> versions = null,
            PluginStatus status = PluginStatus.Normal,
            string dboLink = "",
            string website = "")
        {
            this.Main = main;
            this.Name = name;
            this.Description = description;
            if (authors == null)
            {
                this.AuthorsList = new List<string>();
            }
            else
            {
                this.AuthorsList = authors;
            }

            if (versions == null)
            {
                this.VersionsList = new List<BukgetPluginVersion>();
            }
            else
            {
                this.VersionsList = versions;
            }

            CategoryList = new List<PluginCategory>();

            this.Status = status;
            this.BukkitDevLink = dboLink;
            this.Website = website;
        }
    }
}