// UpdaterSettings.cs in bukkitgui2/bukkitgui2
// Created 2014/08/08
// Last edited at 2014/08/08 17:48
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.Core;
using Net.Bertware.Get;

namespace Net.Bertware.Bukkitgui2.AddOn.Updater
{
	public partial class UpdaterSettings : UserControl
	{
		public UpdaterSettings()
		{
			InitializeComponent();
		}

		private void UpdaterSettings_Load(object sender, EventArgs e)
		{
			lblInfoAppName.Text = "Name: " + Share.AssemblyName;
			lblInfoAppVersion.Text = "Version: " + Share.AssemblyVersion;
			lblInfoAppCopyright.Text = "Copyright: " + Share.AssemblyCopyRight;
			lblInfoAppAuthors.Text = "Authors: " + Share.AssemblyCompany;
			lblInfoAppLatest.Text = "Latest version: " + api.LatestVersion.Version;
		}

		private void BtnInfoAppUpdater_Click(object sender, EventArgs e)
		{
			api.ShowUpdater();
		}
	}
}