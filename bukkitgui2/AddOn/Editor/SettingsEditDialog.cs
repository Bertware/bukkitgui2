// SettingsEditDialog.cs in bukkitgui2/bukkitgui2
// Created 2014/08/27
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Net.Bertware.Bukkitgui2.AddOn.Editor
{
    public partial class SettingsEditDialog : MetroForm
    {
        public SettingsEditDialog()
        {
            InitializeComponent();
			txtSetting.ReadOnly = false;
			Text = "Add Setting";
        }

        public SettingsEditDialog(string setting, string value)
        {
            InitializeComponent();
            txtSetting.ReadOnly = true; // make setting name readonly
            txtSetting.Text = setting;
            txtValue.Text = value;
            txtValue.Focus(); // focus value textbox
        }

        public string Setting
        {
            get { return txtSetting.Text; }
        }

        public string Value
        {
            get { return txtValue.Text; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}