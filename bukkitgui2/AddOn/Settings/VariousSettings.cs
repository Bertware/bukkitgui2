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
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.Core.FileLocation;

namespace Net.Bertware.Bukkitgui2.AddOn.Settings
{
    public partial class VariousSettings : MetroUserControl
    {
        public VariousSettings()
        {
            InitializeComponent();
            chkSaveInServerDir.Checked = Fl.GetLocal();
        }

        private void appShortcutToDesktop(string linkName, string args)
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
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = true
            };
            dialog.ShowDialog();
            appShortcutToDesktop("BukkitGui custom dir", " -wd=\"" + dialog.SelectedPath + "\"");
        }

        private void chkSaveInServerDir_CheckedChanged(object sender, EventArgs e)
        {
            Fl.SetLocal(chkSaveInServerDir.Checked);
        }
    }
}