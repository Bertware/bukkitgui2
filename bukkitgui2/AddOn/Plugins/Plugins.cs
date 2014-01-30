using System;
using System.Text;
using System.Windows.Forms;

namespace bukkitgui2.AddOn.Plugins
{
	class Plugins : IAddon
	{
		private TabPage _tab = null;

		/// <summary>
		/// The addon name, ideally this name is the same as used in the tabpage
		/// </summary>
		public string name
		{
			get
			{
				return "Plugins";
			}
		}

		/// <summary>
		/// Initialize all functions and the tabcontrol
		/// </summary>
		void IAddon.Initialize()
		{
			_tab = new PluginsTab();
			_tab.Text = this.name;
		}

		/// <summary>
		/// The tab control for this addon
		/// </summary>
		/// <returns>Returns the tabpage</returns>
		TabPage IAddon.Tabpage
		{
			get
			{
				return _tab;
			}
		}
	}
}
