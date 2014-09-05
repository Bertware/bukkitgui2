// TaskerTab.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
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
using Net.Bertware.Bukkitgui2.AddOn.Tasker.TaskerUI;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker
{
	public partial class TaskerTab : MetroUserControl, IAddonTab
	{
		public TaskerTab()
		{
			InitializeComponent();
			LoadUi();
			Tasker.Reference.TaskListAltered += OnTaskListAltered;
		}

		private void OnTaskListAltered(object sender, EventArgs e)
		{
			LoadUi();
		}

		public IAddon ParentAddon { get; set; }

		/// <summary>
		///     Load all tasks to the UI
		/// </summary>
		private void LoadUi()
		{
			slvTasks.Items.Clear();
			foreach (KeyValuePair<string, Task> pair in Tasker.Tasks)
			{
				string[] content =
				{
					pair.Key,
					pair.Value.Trigger.Name,
					pair.Value.Trigger.Parameters,
					pair.Value.Actions[0].Name,
					pair.Value.Actions[0].Parameters,
					pair.Value.Enabled.ToString()
				};
				ListViewItem lvi = new ListViewItem(content) {Tag = pair.Value};
				slvTasks.Items.Add(lvi);
			}
		}

		private void btnNew_Click(object sender, EventArgs e)
		{
			TaskEditor editor = new TaskEditor();
			editor.ShowDialog();
		}

		private void slvTasks_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnEdit.Enabled = (slvTasks.SelectedItems.Count > 0);
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (slvTasks.SelectedItems.Count < 1) return;
			Task t = (Task) slvTasks.SelectedItems[0].Tag;
			TaskEditor editor = new TaskEditor(t);
			editor.ShowDialog();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			Task t = (Task) slvTasks.SelectedItems[0].Tag;
			Tasker.Reference.DeleteTask(t);
		}
	}
}