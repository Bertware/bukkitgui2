namespace Bukkitgui2.AddOn.Plugins.BukgetPlugins
{
    /// <summary>
    ///     A plugin list item is a simplified plugin that only contains crucial data for the user.
    ///     Name and description are included to allow browsing plugin lists, Last version and bukkit version info is included
    ///     to allow for auto-updaters.
    ///     Main namespace should be used as a unique kay value to find plugins
    /// </summary>
    public class BukgetPluginListItem
    {
        /// <summary>
        ///     The name of this plugin
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///     The description of this plugin
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        ///     The last version of this plugin
        /// </summary>
        public string LastVersion { get; private set; }

        /// <summary>
        ///     The last bukkit version that is supported by this plugin
        /// </summary>
        public string LastBukkit { get; private set; }

        /// <summary>
        ///     The main namespace this plugin
        /// </summary>
        public string Main { get; private set; }

        /// <summary>
        ///     Create a new BukgetPluginListItem object with the given values
        /// </summary>
        /// <param name="main">The main namespace this plugin</param>
        /// <param name="name">The name this plugin</param>
        public BukgetPluginListItem(string main, string name)
        {
            this.SetFields(main, name);
        }

        /// <summary>
        ///     Create a new BukgetPluginListItem object with the given values
        /// </summary>
        /// <param name="main">The main namespace this plugin</param>
        /// <param name="name">The name this plugin</param>
        /// <param name="description">The description this plugin</param>
        public BukgetPluginListItem(string main, string name, string description)
        {
            this.SetFields(main, name, description);
        }

        /// <summary>
        ///     Create a new BukgetPluginListItem object with the given values
        /// </summary>
        /// <param name="main">The main namespace this plugin</param>
        /// <param name="name">The name this plugin</param>
        /// <param name="description">The description this plugin</param>
        /// <param name="lastVersion">The last version of this plugin</param>
        /// <param name="lastBukkit">The last bukkit version that is supported by this plugin</param>
        public BukgetPluginListItem(
            string main,
            string name,
            string description,
            string lastVersion,
            string lastBukkit)
        {
            this.SetFields(main, name, description, lastVersion, lastBukkit);
        }

        /// <summary>
        ///     Save field values for all fields (with default values)
        /// </summary>
        /// <param name="main">The main namespace this plugin</param>
        /// <param name="name">The name this plugin</param>
        /// <param name="description">The description this plugin</param>
        /// <param name="lastVersion">The last version of this plugin</param>
        /// <param name="lastBukkit">The last bukkit version that is supported by this plugin</param>
        /// <remarks> This method is used to prevent code duplication in the contructors </remarks>
        private void SetFields(
            string main,
            string name,
            string description = "",
            string lastVersion = "",
            string lastBukkit = "")
        {
            this.Name = name;
            this.Description = description;
            this.LastVersion = lastVersion;
            this.LastBukkit = lastBukkit;
            this.Main = main;
        }
    }
}