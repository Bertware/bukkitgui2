// BackupTab.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/08/31 12:22
// ©Bertware, visit http://bertware.net

using MetroFramework.Controls;

namespace Net.Bertware.Bukkitgui2.AddOn.Backup
{
	public partial class BackupTab : MetroUserControl, IAddonTab
	{
		public BackupTab()
		{
			InitializeComponent();
		}

		public IAddon ParentAddon { get; set; }
	}
}