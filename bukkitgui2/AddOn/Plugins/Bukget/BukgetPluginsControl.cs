// BukgetPluginsControl.cs in bukkitgui2/bukkitgui2
// Created 2014/06/18
// Last edited at 2015/09/01 10:16
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.AddOn.Plugins.Bukget.api3;

namespace Net.Bertware.Bukkitgui2.AddOn.Plugins.Bukget
{
	public partial class BukgetPluginsControl : MetroUserControl
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
			api3.Bukget.GetPluginsByCategory(cbCategories.SelectedItem.ToString());
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			api3.Bukget.SearchPlugins(txtSearchText.Text, 50);
		}

		private void ShowPluginInfo(object sender, EventArgs e)
		{
			if (slvPlugins.SelectedItems.Count < 0) return;
			foreach (ListViewItem item in slvPlugins.SelectedItems)
			{
				string main = item.Tag.ToString();
				api3.Bukget.CurrentlyLoadedPlugins[main].ShowVersionDialog();
			}
		}

		/// <summary>
		///     Install the selected plugins on button press
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		private void InstallSelectedPlugins(object sender, EventArgs eventArgs)
		{
			if (slvPlugins.SelectedItems.Count < 0) return;
			foreach (ListViewItem item in slvPlugins.SelectedItems)
			{
				string main = item.Tag.ToString();
				api3.Bukget.CurrentlyLoadedPlugins[main].InstallLatestVersion();
			}
		}

		private void slvPlugins_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool selected = slvPlugins.SelectedItems.Count > 0;
			btnInfo.Enabled = selected;
			btnInstall.Enabled = selected;
		}

		private void txtSearchText_KeyDown(object sender, KeyEventArgs e)
		{
			// TODO: prevent beep noise on enter
			if (e.KeyCode != Keys.Enter) return;
			e.Handled = true;
			btnSearch_Click(sender, e);
		}

		private void CBtnRefresh_Click(object sender, EventArgs e)
		{
			// Event handlers will do the rest
			// Just load most popular, there's search etc for other stuff
			api3.Bukget.GetMostPopularPlugins(30);
		}

		private void CBtnViewOnline_Click(object sender, EventArgs e)
		{
			if (slvPlugins.SelectedItems.Count < 0) return;
			foreach (ListViewItem item in slvPlugins.SelectedItems)
			{
				string main = item.Tag.ToString();
				api3.Bukget.CurrentlyLoadedPlugins[main].OpenBukkitdevPage();
			}
		}

		private void CtxPlugins_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			CtxPlugins.Enabled = (slvPlugins.SelectedItems.Count > 0);
		}
	}
}