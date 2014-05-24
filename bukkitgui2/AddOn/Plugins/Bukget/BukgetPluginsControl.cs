// BukgetPluginsControl.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/05/24 12:16
// ©Bertware, visit http://bertware.net

using System.Collections.Generic;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.AddOn.Plugins.Bukget.api3;

namespace Net.Bertware.Bukkitgui2.AddOn.Plugins.Bukget
{
	public partial class BukgetPluginsControl : UserControl
	{

		private List<BukgetPlugin> _plugins; 

		public BukgetPluginsControl()
		{
			InitializeComponent();
		}

		private void BukgetPluginsControl_VisibleChanged(object sender, System.EventArgs e)
		{
			if (Visible && (_plugins == null || _plugins.Count < 1))
			{
				_plugins = api3.Bukget.GetMostPopularPlugins(20);
				ShowPlugins();
			}
		}

		private void ShowPlugins()
		{
			this.slvPlugins.Items.Clear();
			foreach (BukgetPlugin p in _plugins)
			{
				string[] contents = {p.Name, p.Description, p.LastVersionNumber, p.LastGameVersion};
				ListViewItem i = new ListViewItem(contents) {Tag = p.Name};
				slvPlugins.Items.Add(i);
			}
		}
	}
}