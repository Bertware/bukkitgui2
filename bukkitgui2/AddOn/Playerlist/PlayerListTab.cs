// PlayerListTab.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/06/22 12:34
// ©Bertware, visit http://bertware.net

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
            slvPlayers.Items.Clear();
            foreach (Player player in PlayerHandler.GetOnlinePlayers())
            {
                string[] contents = {player.Name, player.DisplayName, player.Ip, player.JoinTime.ToLongTimeString()};
                ListViewItem item = new ListViewItem(contents) {Tag = player.Name};
                slvPlayers.Items.Add(item);
            }
        }

        public IAddon ParentAddon { get; set; }
    }
}