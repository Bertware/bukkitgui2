using System.Windows.Forms;

namespace Net.Bertware.Bukkitgui2.AddOn.Backup
{
	public partial class BackupTab : UserControl, IAddonTab
	{
		public BackupTab()
		{
			InitializeComponent();
		}

		public IAddon ParentAddon { get; set; }
	}
}