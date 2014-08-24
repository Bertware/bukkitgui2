// PlayerList.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/08/17 11:19
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.Core.Configuration;
using Net.Bertware.Bukkitgui2.MinecraftInterop.PlayerHandler;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;
using Net.Bertware.Bukkitgui2.MinecraftServers;

namespace Net.Bertware.Bukkitgui2.AddOn.PlayerList
{
    internal class PlayerList : IAddon
    {
		/// <summary>
		/// Reference to the latest created playerlist instance
		/// </summary>
	    public static PlayerList Reference;

	    public PlayerList()
	    {
		    Reference = this;
	    }

        /// <summary>
        ///     The addon name, ideally this name is the same as used in the tabpage
        /// </summary>
        public string Name
        {
            get { return "Players"; }
        }

        /// <summary>
        ///     True if this addon has a tab page
        /// </summary>
        public bool HasTab
        {
            get { return true; }
        }

        /// <summary>
        ///     True if this addon has a config field
        /// </summary>
        public bool HasConfig
        {
            get { return false; }
        }

        /// <summary>
        ///     Initialize all functions and the tabcontrol
        /// </summary>
        public void Initialize()
        {
            PlayerHandler.Initialize();
            TabPage = new PlayerListTab {Text = Name, ParentAddon = this};
	        ConfigPage = null;
        }

        public void Dispose()
        {
            // nothing to do
        }

        /// <summary>
        ///     The tab control for this addon
        /// </summary>
        /// <returns>Returns the tabpage</returns>
        public UserControl TabPage { get; private set; }

        public UserControl ConfigPage { get; private set; }

        public bool CanDisable
        {
            get { return true; }
        }

    }
}