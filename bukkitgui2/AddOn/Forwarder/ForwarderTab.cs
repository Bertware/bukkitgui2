// ForwarderTab.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/05/17 19:43
// ©Bertware, visit http://bertware.net

using System.Windows.Forms;

namespace Net.Bertware.Bukkitgui2.AddOn.Forwarder
{
	public partial class ForwarderTab : UserControl, IAddonTab
	{
		public ForwarderTab()
		{
			InitializeComponent();
		}

		public IAddon ParentAddon { get; set; }
	}
}