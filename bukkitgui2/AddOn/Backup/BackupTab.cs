// BackupTab.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.Core.Util;

namespace Net.Bertware.Bukkitgui2.AddOn.Backup
{
	public partial class BackupTab : MetroUserControl, IAddonTab
	{
		public BackupTab()
		{
			InitializeComponent();
			Backup.Reference.BackupsLoaded += UpdateUi;
		}

		public IAddon ParentAddon { get; set; }

		public void UpdateUi()
		{
			if (!Backup.Reference.Loaded ) return;

			try
			{
				if (InvokeRequired)
				{
					Invoke((MethodInvoker) UpdateUi);
				}
				else
				{
					SlvBackups.Items.Clear();
					foreach (BackupDefenition backup in Backup.Reference.Backups.Values)
					{
						ListViewItem lvi = new ListViewItem(
							new[]
							{
								backup.Name,
								StringUtil.ListToCsv(backup.Folders),
								backup.TargetDirectory,
								backup.Compression.ToString()
							}) {Tag = backup};
						SlvBackups.Items.Add(lvi);
					}
				}
			}
			catch (Exception ex)
			{
				Logger.Log(LogLevel.Severe, "mainform", "Severe exception in Backupmanager_UpdateUI! " + ex.Message, "mainform");
			}
		}

		private void BtnBackupAdd_Click(Object sender, EventArgs e)
		{
			BackupDialog bd = new BackupDialog();
			if (bd.ShowDialog() == DialogResult.OK)
				Backup.Reference.AddBackupToXml(bd.Defenition);
			UpdateUi();
		}

		private void BtnBackupEdit_Click(Object sender, EventArgs e)
		{
			if (SlvBackups.SelectedItems.Count < 1 || SlvBackups.SelectedItems[0] == null)
				return;
			BackupDefenition backup = Backup.Reference.GetBackupByName(SlvBackups.SelectedItems[0].SubItems[0].Text);
			BackupDialog bd = new BackupDialog(backup);
			if (bd.ShowDialog() == DialogResult.OK)
				Backup.Reference.SaveBackup(backup, bd.Defenition);
			UpdateUi();
		}

		private void BtnBackupRemove_Click(Object sender, EventArgs e)
		{
			if (SlvBackups.SelectedItems.Count < 1 || SlvBackups.SelectedItems[0] == null)
				return;
			BackupDefenition backup = Backup.Reference.GetBackupByName(SlvBackups.SelectedItems[0].SubItems[0].Text);
			Backup.Reference.DeleteBackup(backup);
			UpdateUi();
		}

		private void BtnBackupExecute_Click(Object sender, EventArgs e)
		{
			if (SlvBackups.SelectedItems.Count < 1 || SlvBackups.SelectedItems[0] == null)
				return;
			BackupDefenition backup = Backup.Reference.GetBackupByName(SlvBackups.SelectedItems[0].SubItems[0].Text);
			backup.Execute();
		}
	}
}