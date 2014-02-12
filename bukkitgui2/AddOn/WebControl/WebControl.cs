using System.Windows.Forms;

namespace Bukkitgui2.AddOn.WebControl
{
	class WebControl : IAddon
	{
		private TabPage _tab = null;
		
		/// <summary>
		/// The addon name, ideally this name is the same as used in the tabpage
		/// </summary>
		public string Name
		{
			get
			{
				return "Web Control";
			}
		}

		/// <summary>
		/// Initialize all functions and the tabcontrol
		/// </summary>
		void IAddon.Initialize()
		{
			_tab = new WebControlTab();
			_tab.Text = this.Name;
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
