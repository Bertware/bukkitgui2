// ServerSettingsControl.cs in bukkitgui2/bukkitgui2
// Created 2014/08/27
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ServerConfig;

namespace Net.Bertware.Bukkitgui2.AddOn.Editor
{
    public partial class ServerSettingsControl : MetroUserControl
    {
        public ServerSettingsControl()
        {
            InitializeComponent();
        }

        private void ServerSettingsControl_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void UpdateListView()
        {
            Dictionary<string, string> settings = ServerProperties.ServerSettings;
            slvServerSettings.Items.Clear();

            foreach (KeyValuePair<string, string> setting in settings)
            {
                string[] content = {setting.Key, setting.Value};
                ListViewItem lvi = new ListViewItem(content) {Tag = setting.Key};
                slvServerSettings.Items.Add(lvi);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (slvServerSettings.SelectedItems.Count < 1) return;

            string key = slvServerSettings.SelectedItems[0].Tag.ToString();
            string value = ServerProperties.GetServerSetting(key);

            SettingsEditDialog dialog = new SettingsEditDialog(key, value);
            if (dialog.ShowDialog() != DialogResult.OK) return;
            ServerProperties.SetServerSetting(dialog.Setting, dialog.Value);
            UpdateListView();
        }


        private void slvServerSettings_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SettingsEditDialog dialog = new SettingsEditDialog();
            if (dialog.ShowDialog() != DialogResult.OK) return;
            ServerProperties.SetServerSetting(dialog.Setting, dialog.Value);
            UpdateListView();
        }
    }
}