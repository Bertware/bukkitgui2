// BukgetPluginView.cs in bukkitgui2/bukkitgui2
// Created 2014/08/06
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MetroFramework.Forms;
using Net.Bertware.Bukkitgui2.AddOn.Plugins.Bukget.api3;
using Net.Bertware.Bukkitgui2.Core.Translation;
using Net.Bertware.Bukkitgui2.Core.Util;

namespace Net.Bertware.Bukkitgui2.AddOn.Plugins.Bukget
{
	public partial class BukgetPluginView : MetroForm
	{
		public BukgetPluginView()
		{
			InitializeComponent();
		}

		private BukgetPlugin _plugin;

		/// <summary>
		///     Location of the installed plugin, if any
		/// </summary>
		private string _currentPluginVersionPath = "";

		public BukgetPlugin Plugin
		{
			get { return _plugin; }
			set
			{
				_plugin = value;
				LoadPlugin(_plugin);
			}
		}

		public String CurrentPluginVersionPath
		{
			get { return _currentPluginVersionPath; }
			set
			{
				if (!string.IsNullOrEmpty(value)) value = new FileInfo(value).FullName;
				_currentPluginVersionPath = value;
			}
		}

		private void LoadPlugin(BukgetPlugin plugin)
		{
			string detail = Translator.Tr("Name:") + " " + plugin.Name + Environment.NewLine + Environment.NewLine +
			                Translator.Tr("Author(s):") + " " + StringUtil.ListToCsv(plugin.AuthorsList) +
			                Environment.NewLine +
			                Environment.NewLine +
			                Translator.Tr("Description:") + " " + plugin.Description + Environment.NewLine +
			                Environment.NewLine +
			                Translator.Tr("Categories:") + " " + StringUtil.ListToCsv(plugin.CategoryList) +
			                Environment.NewLine +
			                Environment.NewLine +
			                Translator.Tr("Main namespace:") + " " + plugin.Main + Environment.NewLine +
			                Environment.NewLine +
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

		private void BtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnInstall_Click(object sender, EventArgs e)
		{
			if (slvVersions.SelectedItems.Count < 0) return;

			string versionNumber = slvVersions.SelectedItems[0].Tag.ToString();

			foreach (BukgetPluginVersion version in _plugin.VersionsList)
			{
				if (version.VersionNumber.Equals(versionNumber)) version.Install(_currentPluginVersionPath);
			}
		}
	}
}