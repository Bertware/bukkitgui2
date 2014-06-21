// SettingsTab.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/06/07 20:24
// ©Bertware, visit http://bertware.net

using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace Net.Bertware.Bukkitgui2.AddOn.Settings
{
	public partial class SettingsTab : UserControl, IAddonTab
	{
		public bool IsInitialized { get; private set; }

		public IAddon ParentAddon { get; set; }

		private Dictionary<string, UserControl> _settings;

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
			_settings = new Dictionary<string, UserControl>();
			foreach (KeyValuePair<IAddon, UserControl> settingsEntry in AddonManager.SettingsDictionary)
			{
				_settings.Add(settingsEntry.Key.Name, settingsEntry.Value);
				TreeNode node = new TreeNode(settingsEntry.Key.Name) {Name = settingsEntry.Key.Name};
				TVSettings.Nodes.Add(node);
			}
			IsInitialized = true;
		}

		private void TvSettingsAfterSelect(object sender, TreeViewEventArgs e)
		{
			LoadControl(e.Node.Name);
		}

		private void LoadControl(string name)
		{
			if (!_settings.ContainsKey(name))
			{
				return;
			}

			gbSettings.Controls.Clear();
			UserControl control = _settings[name];

			// safety check
			if (control == null) return;

			gbSettings.Controls.Add(control);
			gbSettings.Controls[0].Dock = DockStyle.Fill;
		}
	}
}