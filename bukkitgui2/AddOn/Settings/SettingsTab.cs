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