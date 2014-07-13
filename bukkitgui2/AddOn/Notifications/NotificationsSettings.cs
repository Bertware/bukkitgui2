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
			chkEnable.Checked = Config.ReadBool(Notifications.CfgIdent, "enable", false);
			chkAlways.Checked = Config.ReadBool(Notifications.CfgIdent, "always", false);
			chkOnStatusChange.Checked = Config.ReadBool(Notifications.CfgIdent, "status", false);
			chkOnStatusChange.Checked = Config.ReadBool(Notifications.CfgIdent, "status", false);
			chkOnPlayerJoin.Checked = Config.ReadBool(Notifications.CfgIdent, "join", false);
			chkOnPlayerLeave.Checked = Config.ReadBool(Notifications.CfgIdent, "leave", false);
			chkOnPlayerKick.Checked = Config.ReadBool(Notifications.CfgIdent, "kick", false);
			chkOnPlayerBan.Checked = Config.ReadBool(Notifications.CfgIdent, "ban", false);
		}

		private void chkEnable_CheckedChanged(object sender, EventArgs e)
		{
			gbBalloons.Enabled = chkEnable.Checked;
			gbSound.Enabled = chkEnable.Checked;
			Config.WriteBool(Notifications.CfgIdent, "enable", chkEnable.Checked);
		}

		private void chkAlways_CheckedChanged(object sender, EventArgs e)
		{
			Config.WriteBool(Notifications.CfgIdent, "always", chkEnable.Checked);
		}

		private void chkOnStatusChange_CheckedChanged(object sender, EventArgs e)
		{
			Config.WriteBool(Notifications.CfgIdent, "status", chkOnStatusChange.Checked);
		}

		private void chkOnPlayerJoin_CheckedChanged(object sender, EventArgs e)
		{
			Config.WriteBool(Notifications.CfgIdent, "join", chkOnPlayerJoin.Checked);
		}

		private void chkOnPlayerLeave_CheckedChanged(object sender, EventArgs e)
		{
			Config.WriteBool(Notifications.CfgIdent, "leave", chkOnPlayerLeave.Checked);
		}

		private void chkOnPlayerKick_CheckedChanged(object sender, EventArgs e)
		{
			Config.WriteBool(Notifications.CfgIdent, "kick", chkOnPlayerKick.Checked);
		}

		private void chkOnPlayerBan_CheckedChanged(object sender, EventArgs e)
		{
			Config.WriteBool(Notifications.CfgIdent, "ban", chkOnPlayerBan.Checked);
		}
	}
}