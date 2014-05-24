// SettingsTab.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/05/24 12:16
// ©Bertware, visit http://bertware.net

using System.Collections.Generic;
using System.Windows.Forms;

namespace Net.Bertware.Bukkitgui2.AddOn.Settings
{
	public partial class SettingsTab : UserControl, IAddonTab
	{
		public bool IsInitialized { get; private set; }

		public IAddon ParentAddon { get; set; }

		private Dictionary<string, UserControl> settings;

		public SettingsTab()
		{
			InitializeComponent();
			if (AddonManager.AddonsLoaded)
			{
				Initialize();
			}
		}

		public void Initialize()
		{
			if (IsInitialized)
			{
				return;
			}
			settings = new Dictionary<string, UserControl>();
			foreach (KeyValuePair<IAddon, UserControl> settingsEntry in AddonManager.SettingsDictionary)
			{
				settings.Add(settingsEntry.Key.Name, settingsEntry.Value);
				TVSettings.Nodes.Add(settingsEntry.Key.Name);
			}
		}

		private void TvSettingsAfterSelect(object sender, TreeViewEventArgs e)
		{
			LoadControl(e.Node.Name);
		}

		private void LoadControl(string name)
		{
			if (!settings.ContainsKey(name))
			{
				return;
			}

			PSettingsControl.Controls.Clear();
			PSettingsControl.Controls.Add(settings[name]);
			PSettingsControl.Controls[0].Dock = DockStyle.Fill;
		}
	}
}