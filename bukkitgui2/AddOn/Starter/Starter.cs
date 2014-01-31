using System.Windows.Forms;

namespace bukkitgui2.AddOn.Starter
{
	internal class Starter : IAddon
	{
		private TabPage _tab;

		/// <summary>
		///     The addon name, ideally this name is the same as used in the tabpage
		/// </summary>
		public string name
		{
			get { return "Starter"; }
		}

		/// <summary>
		///     Initialize all functions and the tabcontrol
		/// </summary>
		void IAddon.Initialize()
		{
			_tab = new StarterTab {Text = name};
		}

		/// <summary>
		///     The tab control for this addon
		/// </summary>
		/// <returns>Returns the tabpage</returns>
		TabPage IAddon.Tabpage
		{
			get { return _tab; }
		}
	}
}