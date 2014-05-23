// SettingsTab.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/05/17 19:43
// ©Bertware, visit http://bertware.net

namespace Net.Bertware.Bukkitgui2.AddOn.Settings
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class SettingsTab : UserControl, IAddonTab
    {
        public bool IsInitialized { get; private set; }

        public IAddon ParentAddon { get; set; }

        private Dictionary<string, UserControl> settings;

        public SettingsTab()
        {
            this.InitializeComponent();
            if (AddonManager.AddonsLoaded)
            {
                this.Initialize();
            }
        }

        private void Initialize()
        {
            if (this.IsInitialized)
            {
                return;
            }
            this.settings = new Dictionary<string, UserControl>();
            foreach (KeyValuePair<IAddon, UserControl> settingsEntry in AddonManager.SettingsDictionary)
            {
                this.settings.Add(settingsEntry.Key.Name, settingsEntry.Value);
                this.TVSettings.Nodes.Add(settingsEntry.Key.Name);
            }
        }

        private void TvSettingsAfterSelect(object sender, TreeViewEventArgs e)
        {
            this.LoadControl(e.Node.Name);
        }

        private void LoadControl(string name)
        {
            if (!this.settings.ContainsKey(name))
            {
                return;
            }

            this.PSettingsControl.Controls.Clear();
            this.PSettingsControl.Controls.Add(this.settings[name]);
            this.PSettingsControl.Controls[0].Dock = DockStyle.Fill;
        }
    }
}