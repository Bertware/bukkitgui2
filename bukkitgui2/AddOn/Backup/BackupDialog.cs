// BackupDialog.cs in bukkitgui2/bukkitgui2
// Created 2014/09/12
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MetroFramework.Forms;
using Net.Bertware.Bukkitgui2.Core;
using Net.Bertware.Bukkitgui2.Core.Util;

namespace Net.Bertware.Bukkitgui2.AddOn.Backup
{
    public partial class BackupDialog : MetroForm
    {
        public BackupDefenition Defenition { get; private set; }

        public BackupDialog()
        {
            Load += BackupDialog_Load;
            InitializeComponent();
        }

        public BackupDialog(BackupDefenition defenition)
        {
            Load += BackupDialog_Load;
            InitializeComponent();
            Defenition = defenition;
        }

        private void BackupDialog_Load(Object sender, EventArgs e)
        {
            if (Defenition != null)
            {
                if (Defenition.Name != null)
                    TxtName.Text = Defenition.Name;
                if (Defenition.Folders != null && Defenition.Folders.Count > 0)
                    TxtFolders.Text = StringUtil.ListToCsv(Defenition.Folders, ';');
                if (Defenition.TargetDirectory != null)
                    TxtDestination.Text = Defenition.TargetDirectory;
                ChkCompression.Checked = Defenition.Compression;
            }
        }

        private void BtnCancel_Click(Object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnOk_Click(Object sender, EventArgs e)
        {
            Defenition = new BackupDefenition {Name = TxtName.Text, Folders = new List<string>()};
            foreach (string dir in TxtFolders.Text.Split(';'))
            {
                Defenition.Folders.Add(dir);
            }
            Defenition.TargetDirectory = TxtDestination.Text;
            Defenition.Compression = ChkCompression.Checked;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnBrowseSourceFolders_Click(Object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = Locale.Tr("Select folders to backup");
            if (fb.ShowDialog() != DialogResult.OK)
                return;
            if (string.IsNullOrEmpty(TxtFolders.Text))
                TxtFolders.Text = fb.SelectedPath;
            else
                TxtFolders.Text += ";" + fb.SelectedPath;
            settings_validate();
        }

        private void BtnBrowseDestination_Click(Object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = Locale.Tr("Select folder to store backup");
            if (fb.ShowDialog() != DialogResult.OK)
                return;
            TxtDestination.Text = fb.SelectedPath;
            settings_validate();
        }

        private bool settings_validate()
        {
            BtnOk.Enabled = false;
            if (string.IsNullOrEmpty(TxtName.Text))
            {
                ErrProv.SetError(TxtName, Locale.Tr("The name must be at least 1 character long"));
                return false; 
            }

            if (Backup.Reference.GetBackupByName(TxtName.Text) != null)
            {
                ErrProv.SetError(TxtName, Locale.Tr("This name is already in use!"));
                return false;
            }

            if (!Regex.IsMatch(TxtName.Text, "(\\d|\\w|-|_)+"))
            {
                ErrProv.SetError(TxtName, Locale.Tr("You can only use the following characters: a-z ; 1-9 ; _ ; -"));
                return false;
            }

            ErrProv.SetError(TxtName, "");
            if (string.IsNullOrEmpty(TxtFolders.Text))
            {
                ErrProv.SetError(TxtFolders, Locale.Tr("You need to specify at least 1 directory"));
                return false;
            }
            ErrProv.SetError(TxtFolders, "");
            if (string.IsNullOrEmpty(TxtDestination.Text))
            {
                ErrProv.SetError(TxtDestination, Locale.Tr("You need to specify the destination directory"));
                return false;
            }
            ErrProv.SetError(TxtDestination, "");

            BtnOk.Enabled = true;
            return true;
        }
    }
}