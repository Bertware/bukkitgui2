// SettingsTab.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/05/17 19:43
// ©Bertware, visit http://bertware.net

using System.Windows.Forms;

namespace Net.Bertware.Bukkitgui2.AddOn.Settings
{
	public partial class SettingsTab : UserControl, IAddonTab
	{
		public SettingsTab()
		{
			InitializeComponent();
		}

		public IAddon ParentAddon { get; set; }
	}
}