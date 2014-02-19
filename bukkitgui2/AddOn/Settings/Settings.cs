using System.Windows.Forms;

namespace Bukkitgui2.AddOn.Settings
{
	internal class Settings : IAddon
	{
		public Settings()
		{
			this.Tabpage = null;
		}


		/// <summary>
		///     The tab control for this addon
		/// </summary>
		/// <returns>Returns the tabpage</returns>
		public UserControl Tabpage { get; private set; }

		/// <summary>
		///     The addon name, ideally this name is the same as used in the tabpage
		/// </summary>
		public string Name
		{
			get { return "Settings"; }
		}

		/// <summary>
		///     Initialize all functions and the tabcontrol
		/// </summary>
		void IAddon.Initialize()
		{
			this.Tabpage = new SettingsTab {Text = this.Name};
		}
	}
}