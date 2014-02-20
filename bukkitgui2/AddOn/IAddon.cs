namespace Bukkitgui2.AddOn
{
    using System;
    using System.Windows.Forms;

    internal interface IAddon
    {
        /// <summary>
        ///     The addon name, ideally this name is the same as used in the tabpage
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     True if this addon has a tabpage
        /// </summary>
        Boolean HasTab { get; }

        /// <summary>
        ///     True if this addon has a config field
        /// </summary>
        Boolean HasConfig { get; }

        /// <summary>
        ///     Initialize all functions and the tabcontrol
        /// </summary>
        void Initialize();

        /// <summary>
        ///     The tab control for this addon, if any
        /// </summary>
        /// <returns>Returns the tabpage</returns>
        UserControl TabPage { get; }

        /// <summary>
        ///     The config control for this addon, if any
        /// </summary>
        /// <returns>Returns the tabpage</returns>
        UserControl ConfigPage { get; }
    }
}