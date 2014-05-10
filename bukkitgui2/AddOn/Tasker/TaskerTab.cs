using System.Windows.Forms;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker
{
	public partial class TaskerTab : UserControl, IAddonTab
	{
		public TaskerTab()
		{
			InitializeComponent();
		}

		public IAddon ParentAddon { get; set; }
	}
}