// BanListControl.cs in bukkitgui2/bukkitgui2
// Created 2014/08/29
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using Net.Bertware.Bukkitgui2.MinecraftInterop.PlayerHandler;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ServerConfig;

namespace Net.Bertware.Bukkitgui2.AddOn.Editor
{
	public partial class BanListControl : IAddonTab
	{
		public BanListControl()
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
			foreach (ServerListItem item in ServerList.BannedPlayers.List.Values)
			{
				string[] content = {item.Name, item.Uuid, item.Created, item.Source, item.Expires};
				ListViewItem lvi = new ListViewItem(content) {Tag = item.Name};
				slvList.Items.Add(lvi);
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			string name = MetroPrompt.ShowPrompt("Ban player", "Enter the name of the player you'd like to ban");
			if (string.IsNullOrEmpty(name)) return;

			PlayerActions.BanPlayer(name);

			RefreshList();
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			if (slvList.SelectedItems.Count < 1) return;
			string name = slvList.SelectedItems[0].Tag.ToString();
			if (!string.IsNullOrEmpty(name)) PlayerActions.PardonPlayer(name);

			RefreshList();
		}
	}
}