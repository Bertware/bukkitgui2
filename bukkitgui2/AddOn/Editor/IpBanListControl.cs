// IpBanListControl.cs in bukkitgui2/bukkitgui2
// Created 2014/08/29
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using Net.Bertware.Bukkitgui2.MinecraftInterop.PlayerHandler;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ServerConfig;

namespace Net.Bertware.Bukkitgui2.AddOn.Editor
{
	public partial class IpBanListControl : IAddonTab
	{
		public IpBanListControl()
		{
			InitializeComponent();
		}

		public IAddon ParentAddon { get; set; }

		private void WhitelistControl_Load(object sender, EventArgs e)
		{
			RefreshList();
		}

		private void RefreshList()
		{
			slvList.Items.Clear();
			foreach (ServerListItem item in ServerList.BannedIps.List.Values)
			{
				string[] content = {item.Ip, item.Created, item.Source, item.Expires};
				ListViewItem lvi = new ListViewItem(content) {Tag = item.Ip};
				slvList.Items.Add(lvi);
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			string ip = MetroPrompt.ShowPrompt("Ban ip", "Enter the ip you'd like to ban");
			if (string.IsNullOrEmpty(ip)) return;

			PlayerActions.BanIp(ip);

			RefreshList();
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			if (slvList.SelectedItems.Count < 1) return;
			string ip = slvList.SelectedItems[0].Tag.ToString();
			if (!string.IsNullOrEmpty(ip)) PlayerActions.PardonIp(ip);

			RefreshList();
		}
	}
}