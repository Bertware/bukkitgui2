using System.Windows.Forms;

namespace Bukkitgui2.AddOn.PlayerList
{
	public partial class PlayerListTab : UserControl, IAddonTab
	{
		public PlayerListTab()
		{
			InitializeComponent();
		}

		public IAddon ParentAddon { get; set; }
	}
}