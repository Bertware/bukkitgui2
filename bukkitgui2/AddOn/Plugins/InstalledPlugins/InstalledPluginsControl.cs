// InstalledPluginsControl.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/08/17 11:19
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.AddOn.Plugins.Bukget.api3;
using Net.Bertware.Bukkitgui2.Core.Util;

namespace Net.Bertware.Bukkitgui2.AddOn.Plugins.InstalledPlugins
{
    public partial class InstalledPluginsControl : UserControl
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
                    ListViewItem lvi = new ListViewItem(text) {Tag = pair.Key};
                    slvPlugins.Items.Add(lvi);
                }
            }
        }

        private void btnVersions_Click(object sender, EventArgs e)
        {
            if (slvPlugins.SelectedItems.Count < 0) return;
            string filename = slvPlugins.SelectedItems[0].Tag.ToString();
            InstalledPlugin plugin = InstalledPluginManager.Plugins[filename];
            BukgetPlugin.CreateFromNamespace(plugin.Mainspace).ShowVersionDialog(plugin.Path);
        }
    }
}