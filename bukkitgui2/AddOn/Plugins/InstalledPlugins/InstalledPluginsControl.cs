// InstalledPluginsControl.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/06/22 12:34
// ©Bertware, visit http://bertware.net

using System.Collections.Generic;
using System.Windows.Forms;

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
            slvPlugins.Items.Clear();
            foreach (KeyValuePair<string, InstalledPlugin> pair in InstalledPluginManager.Plugins)
            {
                // TODO: correct text
                string[] text = {pair.Value.Name, pair.Value.Description, pair.Value.Version};
                ListViewItem lvi = new ListViewItem(text) {Tag = pair.Key};
                slvPlugins.Items.Add(lvi);
            }
        }
    }
}