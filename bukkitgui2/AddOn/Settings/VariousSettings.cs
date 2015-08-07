// VariousSettings.cs in bukkitgui2/bukkitgui2
// Created 2014/09/07
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.Core.FileLocation;
using Net.Bertware.Bukkitgui2.Core.Logging;

namespace Net.Bertware.Bukkitgui2.AddOn.Settings
{
	public partial class VariousSettings : MetroUserControl
	{
		public VariousSettings()
		{
			InitializeComponent();
			chkSaveInServerDir.Checked = Fl.GetLocal();
		}

		private static void CreateAppShortcutToDesktop(string linkName, string args)
		{
			string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

			using (StreamWriter writer = new StreamWriter(deskDir + "\\" + linkName + ".url"))
			{
				string app = Assembly.GetExecutingAssembly().Location;
				writer.WriteLine("[InternetShortcut]");
				writer.WriteLine("URL=file:///" + app + " " + args);
				writer.WriteLine("IconIndex=0");
				string icon = app.Replace('\\', '/');
				writer.WriteLine("IconFile=" + icon);
				writer.Flush();
			}
		}

		private void btnCustomFolder_Click(object sender, EventArgs e)
		{
			try
			{
				FolderBrowserDialog dialog = new FolderBrowserDialog
				{
					ShowNewFolderButton = true
				};
				dialog.ShowDialog();
				CreateAppShortcutToDesktop("BukkitGui custom dir", " -wd=\"" + dialog.SelectedPath + "\"");
				MetroMessageBox.Show(Application.OpenForms[0], "A special shortcut has been created on your desktop.",
					"Shortcut created", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception exception)
			{
				MetroMessageBox.Show(Application.OpenForms[0], "Failed to create shortcut! Try running as administrator.",
					"Failed to create shortcut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				Logger.Log(LogLevel.Warning, "VariousSettings", "Failed to create custom folder shortcut", exception.Message);
			}
		}

		private void chkSaveInServerDir_CheckedChanged(object sender, EventArgs e)
		{
			Fl.SetLocal(chkSaveInServerDir.Checked);
		}
	}
}