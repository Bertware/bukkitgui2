// EditorTab.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/08/17 11:19
// ©Bertware, visit http://bertware.net

using System.Windows.Forms;
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

		private void WhitelistControl_Load(object sender, System.EventArgs e)
		{
			RefreshList();
		}

	    private void RefreshList()
	    {
		    slvList.Items.Clear();
		    foreach (ServerListItem item in ServerBanlist.BanList.Values)
		    {
			    string[] content = {item.Name, item.Uuid, item.Created, item.Source, item.Expires};
				ListViewItem lvi = new ListViewItem(content) {Tag = item.Name};
			    slvList.Items.Add(lvi);
		    }
	    }
    }
}