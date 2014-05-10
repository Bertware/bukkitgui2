using System.Windows.Forms;

namespace Net.Bertware.Bukkitgui2.AddOn.WebControl
{
	public partial class WebControlTab : UserControl, IAddonTab
	{
		public WebControlTab()
		{
			InitializeComponent();
		}

		public IAddon ParentAddon { get; set; }
	}
}