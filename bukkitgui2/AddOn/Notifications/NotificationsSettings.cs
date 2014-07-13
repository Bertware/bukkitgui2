// NotificationsSettings.cs in bukkitgui2/bukkitgui2
// Created 2014/06/21
// Last edited at 2014/06/22 12:34
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.Core.Configuration;

namespace Net.Bertware.Bukkitgui2.AddOn.Notifications
{
	public partial class NotificationSettings : UserControl
	{
		public NotificationSettings()
		{
			InitializeComponent();
			chkEnable.Link(Notifications.CfgIdent, "enable", false);
			chkAlways.Link(Notifications.CfgIdent, "always", false);
			chkOnStatusChange.Link(Notifications.CfgIdent, "status", false);
			chkOnStatusChange.Link(Notifications.CfgIdent, "status", false);
			chkOnPlayerJoin.Link(Notifications.CfgIdent, "join", false);
			chkOnPlayerLeave.Link(Notifications.CfgIdent, "leave", false);
			chkOnPlayerKick.Link(Notifications.CfgIdent, "kick", false);
			chkOnPlayerBan.Link(Notifications.CfgIdent, "ban", false);
		}

		private void chkEnable_CheckedChanged(object sender, EventArgs e)
		{
			gbBalloons.Enabled = chkEnable.Checked;
			gbSound.Enabled = chkEnable.Checked;
		}

	}
}