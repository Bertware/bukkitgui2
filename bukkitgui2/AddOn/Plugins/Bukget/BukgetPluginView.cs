// BukgetPluginView.cs in bukkitgui2/bukkitgui2
// Created 2014/08/06
// Last edited at 2014/08/06 10:30
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.AddOn.Plugins.Bukget.api3;
using Net.Bertware.Bukkitgui2.Core.Translation;
using Net.Bertware.Bukkitgui2.Core.Util;

namespace Net.Bertware.Bukkitgui2.AddOn.Plugins.Bukget
{
	public partial class BukgetPluginView : Form
	{
		public BukgetPluginView()
		{
			InitializeComponent();
		}

		private BukgetPlugin _plugin;

		public BukgetPlugin Plugin
		{
			get { return _plugin; }
			set
			{
				_plugin = value;
				LoadPlugin(_plugin);
			}
		}

		private void LoadPlugin(BukgetPlugin plugin)
		{
			string detail = Translator.Tr("Name:") + " " + plugin.Name + Environment.NewLine + Environment.NewLine +
							Translator.Tr("Author(s):") + " " +StringUtil.ListToCsv<string>(plugin.AuthorsList) + Environment.NewLine + Environment.NewLine +
							Translator.Tr("Description:") + " " + plugin.Description + Environment.NewLine + Environment.NewLine +
							Translator.Tr("Categories:") + " " + StringUtil.ListToCsv<PluginCategory>(plugin.CategoryList) + Environment.NewLine + Environment.NewLine +
							Translator.Tr("Main namespace:") + " " + plugin.Main + Environment.NewLine + Environment.NewLine +
							Translator.Tr("Status:") + " " + plugin.Status + Environment.NewLine + Environment.NewLine +
			                Translator.Tr("Website:") + " " + plugin.Website;
			lblPluginDetail.Text = detail;
			LoadVersions(plugin.VersionsList);
		}

		private void LoadVersions(IEnumerable<BukgetPluginVersion> list)
		{
			slvVersions.Items.Clear();
			foreach (BukgetPluginVersion version in list)
			{
				string[] text =
				{
					version.VersionNumber,
					version.Filename,
					StringUtil.ListToCsv(version.CompatibleBuilds),
					version.ReleaseDate.ToShortDateString(),
					version.Type.ToString()
				};

				ListViewItem lvi = new ListViewItem(text) {Tag = version.VersionNumber};
				slvVersions.Items.Add(lvi);
			}
		}
	}
}