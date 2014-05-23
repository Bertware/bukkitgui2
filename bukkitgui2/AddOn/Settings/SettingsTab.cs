// SettingsTab.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/05/17 19:43
// ©Bertware, visit http://bertware.net

using System.Windows.Forms;

namespace Net.Bertware.Bukkitgui2.AddOn.Settings
{
    using System.Collections.Generic;

    public partial class SettingsTab : UserControl, IAddonTab
	{
        public bool IsInitialized { get; private set; }

        public IAddon ParentAddon { get; set; }

        private Dictionary<string, UserControl> settings; 

		public SettingsTab()
		{
			InitializeComponent();
		    if (AddonManager.AddonsLoaded) Initialize();
		}

        private void Initialize()
        {
            if (this.IsInitialized) return;
            settings = new Dictionary<string, UserControl>();
            foreach (KeyValuePair<IAddon,UserControl> settingsEntry in AddonManager.SettingsDictionary)
            {
                settings.Add(settingsEntry.Key.Name,settingsEntry.Value);
                TVSettings.Nodes.Add(settingsEntry.Key.Name);
            }
        }

    }
}