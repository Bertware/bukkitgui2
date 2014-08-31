// Plugins.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// ©Bertware, visit http://bertware.net

using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.AddOn.Plugins.InstalledPlugins;

namespace Net.Bertware.Bukkitgui2.AddOn.Plugins
{
	internal class Plugins : IAddon
	{
		/// <summary>
		///     The addon name, ideally this name is the same as used in the tabpage
		/// </summary>
		public string Name
		{
			get { return "Plugins"; }
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
			TabPage = new PluginsTab {Text = Name, ParentAddon = this};
			ConfigPage = null;

			// TODO: This code locks up the UI for a while
			InstalledPluginManager.Initialize();
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