// BukgetPluginsControl.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/07/19 19:13
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.AddOn.Plugins.Bukget.api3;

namespace Net.Bertware.Bukkitgui2.AddOn.Plugins.Bukget
{
	public partial class BukgetPluginsControl : UserControl
	{
		private Dictionary<string, BukgetPlugin> _plugins;

		public BukgetPluginsControl()
		{
			InitializeComponent();
			foreach (string category in Enum.GetNames(typeof (PluginCategory)))
			{
				cbCategories.Items.Add(category.Replace("__", "-").Replace("_", " "));
			}
			api3.Bukget.NewPluginsLoaded += UpdatePluginsDictionary;
		}

		private void UpdatePluginsDictionary(Dictionary<string, BukgetPlugin> currentlyLoadedPlugins)
		{
			_plugins = currentlyLoadedPlugins;
			ShowPlugins();
		}

		private void BukgetPluginsControl_VisibleChanged(object sender, EventArgs e)
		{
			if (!Visible || (_plugins != null && _plugins.Count >= 1)) return;
			api3.Bukget.GetMostPopularPlugins(20);
		}

		private void ShowPlugins()
		{
			slvPlugins.Items.Clear();
			foreach (BukgetPlugin p in _plugins.Values)
			{
				string[] contents = {p.Name, p.Description, p.LastVersionNumber, p.LastGameVersion};
				ListViewItem i = new ListViewItem(contents) {Tag = p.Main};
				slvPlugins.Items.Add(i);
			}
		}


		private void cbCategories_SelectedIndexChanged(object sender, EventArgs e)
		{
			api3.Bukget.GetPluginsByCategory(cbCategories.SelectedItem.ToString(), 50000);
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			api3.Bukget.SearchPlugins(txtSearchText.Text, 50);
		}

		private void btnInfo_Click(object sender, EventArgs e)
		{
			if (slvPlugins.SelectedItems.Count < 0) return;
			string main = slvPlugins.SelectedItems[0].Tag.ToString();
			api3.Bukget.CurrentlyLoadedPlugins[main].ShowVersionDialog();

		}

		private void btnInstall_Click(object sender, EventArgs e)
		{
			if (slvPlugins.SelectedItems.Count < 0) return;
			string main = slvPlugins.SelectedItems[0].Tag.ToString();
			api3.Bukget.CurrentlyLoadedPlugins[main].InstallLatestVersion();
		}
	}
}