using System.Windows.Forms;

namespace Net.Bertware.Bukkitgui2.AddOn.Editor
{
	public partial class EditorTab : UserControl, IAddonTab
	{
		public EditorTab()
		{
			InitializeComponent();
		}

		public IAddon ParentAddon { get; set; }
	}
}