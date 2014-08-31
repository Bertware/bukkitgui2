// SettingsTab.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// ©Bertware, visit http://bertware.net

using System.Collections.Generic;
using System.Windows.Forms;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.Core.Configuration;

namespace Net.Bertware.Bukkitgui2.AddOn.Settings
{
	public partial class SettingsTab : MetroUserControl, IAddonTab
	{
		public bool IsInitialized { get; private set; }

		public IAddon ParentAddon { get; set; }

		/// <summary>
		///     Dictionary of addon names and their settings controls
		/// </summary>
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
			TreeNode node;

			foreach (KeyValuePair<IAddon, UserControl> settingsEntry in AddonManager.SettingsDictionary)
			{
				_settings.Add(settingsEntry.Key.Name, settingsEntry.Value);
				node = new TreeNode(settingsEntry.Key.Name) {Name = settingsEntry.Key.Name};
				TVSettings.Nodes.Add(node);
			}
			_settings.Add("Credits", new Credits());
			node = new TreeNode("Credits") {Name = "Credits"};
			TVSettings.Nodes.Add(node);
			IsInitialized = true;
		}

		/// <summary>
		///     Handle the selection of a different node in the treeview
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TvSettingsAfterSelect(object sender, TreeViewEventArgs e)
		{
			Config.SaveFile(); //autosave the file while editing different settings groups
			LoadControl(e.Node.Name);
		}

		/// <summary>
		///     Load a new settings control
		/// </summary>
		/// <param name="name"></param>
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