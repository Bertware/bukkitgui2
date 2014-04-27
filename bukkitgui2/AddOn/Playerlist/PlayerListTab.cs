namespace Net.Bertware.Bukkitgui2.AddOn.PlayerList
{
    using System.Windows.Forms;

    using  Net.Bertware.Bukkitgui2.MinecraftInterop.PlayerHandler;

    public partial class PlayerListTab : UserControl, IAddonTab
    {
        public PlayerListTab()
        {
            this.InitializeComponent();
            PlayerHandler.PlayerListChanged += this.HandlePlayerListChange;
        }

        private void HandlePlayerListChange()
        {
            this.slvPlayers.Items.Clear();
            foreach (Player player in PlayerHandler.OnlinePlayers.Values)
            {
                string[] contents = { player.Name, player.DisplayName, player.Ip, player.JoinTime.ToLongTimeString() };
                ListViewItem item = new ListViewItem(contents) { Tag = player.Name };
                this.slvPlayers.Items.Add(item);
            }
        }

        public IAddon ParentAddon { get; set; }
    }
}