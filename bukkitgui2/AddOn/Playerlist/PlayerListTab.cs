// PlayerListTab.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/08/17 11:19
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.MinecraftInterop.PlayerHandler;

namespace Net.Bertware.Bukkitgui2.AddOn.PlayerList
{
	public partial class PlayerListTab : UserControl, IAddonTab
	{
		public PlayerListTab()
		{
			InitializeComponent();
			PlayerHandler.PlayerListChanged += HandlePlayerListChange;
		}

		private void HandlePlayerListChange()
		{
			if (this.InvokeRequired)
			{
				this.Invoke((MethodInvoker) HandlePlayerListChange);
			}
			else
			{
				slvPlayers.Items.Clear();
				foreach (Player player in PlayerHandler.GetOnlinePlayers())
				{
					string[] contents = { player.Name, player.DisplayName, player.Ip, player.JoinTime.ToLongTimeString() , player.Location};
					ListViewItem item = new ListViewItem(contents) { Tag = player.Name };
					slvPlayers.Items.Add(item);
					player.DetailsLoaded+=player_DetailsLoaded;
				}
			}
			
		}

		private void player_DetailsLoaded(object sender, EventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke((MethodInvoker) (() => player_DetailsLoaded(sender,e)));
			}
			else
			{
				Player p = (Player) sender;
				foreach (ListViewItem lvi in slvPlayers.Items)
				{

					if (lvi.Tag.Equals(p.Name))
					{
						lvi.SubItems[4].Text = p.Location;
					}

				}
			}
		}

		public IAddon ParentAddon { get; set; }
	}
}