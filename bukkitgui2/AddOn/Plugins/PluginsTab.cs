using System.Windows.Forms;

namespace Net.Bertware.Bukkitgui2.AddOn.Plugins
{
	public partial class PluginsTab : UserControl, IAddonTab
	{
		public PluginsTab()
		{
			InitializeComponent();
		}

		public IAddon ParentAddon { get; set; }
	}
}