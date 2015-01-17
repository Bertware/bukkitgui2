// InstalledPluginsControl.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.AddOn.Plugins.Bukget.api3;
using Net.Bertware.Bukkitgui2.Core.FileLocation;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.Core.Util;

namespace Net.Bertware.Bukkitgui2.AddOn.Plugins.InstalledPlugins
{
    public partial class InstalledPluginsControl : MetroUserControl
    {
        public InstalledPluginsControl()
        {
            InitializeComponent();
            InstalledPluginManager.InstalledPluginListLoadedSimpleList += UpdateListView;
            InstalledPluginManager.InstalledPluginListLoadedFullList += UpdateListView;
        }

        private void UpdateListView()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker) UpdateListView);
            }
            else
            {
                slvPlugins.Items.Clear();
                foreach (KeyValuePair<string, InstalledPlugin> pair in InstalledPluginManager.Plugins)
                {
                    // TODO: correct text
                    string[] text =
                    {
                        pair.Value.Name, pair.Value.Description, StringUtil.ListToCsv(pair.Value.Authors),
                        pair.Value.Version, "",
                        pair.Value.FileCreationDate.ToShortDateString()
                    };
                    ListViewItem lvi = new ListViewItem(text) {Tag = pair.Value};
                    slvPlugins.Items.Add(lvi);
                }
            }
        }

        private void btnVersions_Click(object sender, EventArgs e)
        {
            if (slvPlugins.SelectedItems.Count < 0) return;
            string filename = ((InstalledPlugin) (slvPlugins.SelectedItems[0].Tag)).FileName;
            InstalledPlugin plugin = InstalledPluginManager.Plugins[filename];
	        try
	        {
		        BukgetPlugin.CreateFromNamespace(plugin.Mainspace).ShowVersionDialog(plugin.Path);
	        }
	        catch (Exception ex)
	        {
				Logger.Log(LogLevel.Warning, "InstalledPlugins","Couldn't get versions dialog for plugin",ex.Message);
		        MetroMessageBox.Show(Application.OpenForms[0],
			        "Couldn't retrieve plugin data for this plugin. Maybe this plugin or version is not in the database",
			        "Couldn't retrieve data", MessageBoxButtons.OK, MessageBoxIcon.Error);
	        }
			
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (slvPlugins.SelectedItems.Count < 0) return;
            List<InstalledPlugin> plugins = new List<InstalledPlugin>();
            foreach (ListViewItem item in slvPlugins.SelectedItems)
            {
                plugins.Add((InstalledPlugin) item.Tag);
            }
            PluginUpdater updater = new PluginUpdater(plugins);
            updater.Show();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (slvPlugins.SelectedItems.Count < 0) return;
            foreach (ListViewItem item in slvPlugins.SelectedItems)
            {
                InstalledPlugin plugin = (InstalledPlugin) item.Tag;
                if (
                    MetroMessageBox.Show(Application.OpenForms[0],
                        "Are you sure you want to delete this plugin?" + Environment.NewLine + plugin.Name,
                        "Delete this plugin?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    plugin.Remove();
            }
			slvPlugins_SelectedIndexChanged(null,null); // force index check to disable buttons if needed
        }

		private void slvPlugins_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool selected = (slvPlugins.SelectedItems.Count > 0);
			btnRemove.Enabled = selected;
			btnUpdate.Enabled = selected;
			btnVersions.Enabled = selected;
		}

		private void btnOpenFolder_Click(object sender, EventArgs e)
		{
			Process.Start(Fl.SafeLocation(RequestFile.Plugindir));
		}
    }
}