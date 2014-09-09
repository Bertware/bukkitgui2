// UpdaterSettings.cs in bukkitgui2/bukkitgui2
// Created 2014/08/08
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.Core;
using Net.Bertware.Get;

namespace Net.Bertware.Bukkitgui2.AddOn.Updater
{
	public partial class UpdaterSettings : MetroUserControl
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