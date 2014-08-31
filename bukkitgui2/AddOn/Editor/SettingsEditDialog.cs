// SettingsEditDialog.cs in bukkitgui2/bukkitgui2
// Created 2014/08/27
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
			Text = "Add Setting";
			txtSetting.ReadOnly = false;
		}

		public SettingsEditDialog(string setting, string value)
		{
			InitializeComponent();
			txtSetting.ReadOnly = true;
			txtSetting.Text = setting;
			txtValue.Text = value;
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