using System.Windows.Forms;

namespace Net.Bertware.Bukkitgui2.AddOn.Permissions
{
	public partial class PermissionsTab : UserControl, IAddonTab
	{
		public PermissionsTab()
		{
			InitializeComponent();
		}

		public IAddon ParentAddon { get; set; }
	}
}