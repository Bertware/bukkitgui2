// EditorTab.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/08/17 11:19
// ©Bertware, visit http://bertware.net

using System.Windows.Forms;
using MetroFramework.Forms;
using Net.Bertware.Bukkitgui2.MinecraftInterop.PlayerHandler;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ServerConfig;

namespace Net.Bertware.Bukkitgui2.AddOn.Editor
{
    public partial class WhitelistControl : IAddonTab
    {
		public WhitelistControl()
        {
            InitializeComponent();
		}

        public IAddon ParentAddon { get; set; }

		private void WhitelistControl_Load(object sender, System.EventArgs e)
		{
			RefreshList();
		}

	    private void RefreshList()
	    {
		    slvList.Items.Clear();
		    foreach (ServerListItem item in ServerWhitelist.Whitelist.Values)
		    {
			    string[] content = {item.Name, item.Uuid};
				ListViewItem lvi = new ListViewItem(content) {Tag = item.Name};
			    slvList.Items.Add(lvi);
		    }
	    }

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			string name = MetroPrompt.ShowPrompt("Whitelist player", "Enter the name of the player you'd like to whitelist");
			if (string.IsNullOrEmpty(name)) return;

			PlayerActions.SetPlayerWhitelist(name,true);

			RefreshList();
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			if (slvList.SelectedItems.Count<1) return;
			string name = slvList.SelectedItems[0].Tag.ToString();
			if(!string.IsNullOrEmpty(name)) PlayerActions.SetPlayerWhitelist(name, false);
			RefreshList();
		}
    }
}