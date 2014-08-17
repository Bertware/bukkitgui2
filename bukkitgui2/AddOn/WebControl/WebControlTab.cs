// WebControlTab.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/08/17 11:19
// ©Bertware, visit http://bertware.net

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