// TaskEditor.cs in bukkitgui2/bukkitgui2
// Created 2014/08/19
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using Net.Bertware.Bukkitgui2.AddOn.Tasker.Action;
using Net.Bertware.Bukkitgui2.AddOn.Tasker.Trigger;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.TaskerUI
{
    public partial class TaskEditor : MetroForm
    {
        private readonly Task _taskToEdit;

        private ITrigger _selectedTrigger;

        public TaskEditor()
        {
            InitializeComponent();
            PopulateUi();
        }

        public TaskEditor(Task taskToEdit)
        {
            _taskToEdit = taskToEdit;
            InitializeComponent();
            PopulateUi();
        }

        /// <summary>
        ///     Load Triggers
        /// </summary>
        private void PopulateUi()
        {
            cbTrigger.Items.Clear();
            foreach (ITrigger trigger in Task.AllTriggers)
            {
                cbTrigger.Items.Add(trigger.Name);
                if (_taskToEdit != null && _taskToEdit.Trigger.Name.Equals(trigger.Name))
                    cbTrigger.SelectedIndex = cbTrigger.Items.Count - 1; //select last
            }

            if (_taskToEdit == null) return;

            txtName.Text = _taskToEdit.Name;
            chkEnable.Checked = _taskToEdit.Enabled;
            txtTriggerParam.Text = _taskToEdit.Trigger.Parameters;
            foreach (IAction action in _taskToEdit.Actions)
            {
                AddActionControl();
                ActionSelector selector = ((ActionSelector) gbAction.Controls[gbAction.Controls.Count - 1]);
                selector.SetAction(action);
            }
        }

        /// <summary>
        ///     Trigger changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbTrigger_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ITrigger trigger in Task.AllTriggers)
            {
                if (cbTrigger.SelectedItem.ToString().Equals(trigger.Name)) _selectedTrigger = trigger;
            }
            if (_selectedTrigger != null)
            {
                lblTriggerDescription.Text = _selectedTrigger.ParameterDescription;
            }
        }

        /// <summary>
        ///     Validate trigger
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTriggerParam_TextChanged(object sender, EventArgs e)
        {
            if (_selectedTrigger == null) return;

            if (_selectedTrigger.ValidateInput(txtTriggerParam.Text))
            {
                errorProvider.SetError(txtTriggerParam, "");
            }
            else
            {
                errorProvider.SetError(txtTriggerParam,
                    "Invalid parameter!" + Environment.NewLine + _selectedTrigger.ParameterDescription);
            }
        }

        /// <summary>
        ///     Handle button click for adding a new action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewaction_Click(object sender, EventArgs e)
        {
            AddActionControl();
        }

        /// <summary>
        ///     Add an action control
        /// </summary>
        private void AddActionControl()
        {
            Height += 180;
            ActionSelector selector = new ActionSelector(gbAction.Controls.Count)
            {
                Location = new Point(6, 50 + 180*(gbAction.Controls.Count - 1)),
                Size = new Size(448, 175),
                Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top)
            };
            gbAction.Controls.Add(selector);
            if (gbAction.Controls.Count > 4) btnNewAction.Enabled = false;
        }

        /// <summary>
        ///     Save task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Task t = ParseFields();
            if (_taskToEdit == null)
            {
                Tasker.Reference.AddTask(t);
            }
            else
            {
                Tasker.Reference.SaveTask(_taskToEdit, t);
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        ///     Cancel edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private Task ParseFields()
        {
            ITrigger trigger = _selectedTrigger;
            trigger.Parameters = txtTriggerParam.Text;
            List<IAction> actions = new List<IAction>();

            foreach (Control control in gbAction.Controls)
            {
                if (!(control is ActionSelector)) continue;
                ActionSelector selector = (ActionSelector) control;
                actions.Add(selector.GetAction());
            }
            return new Task(txtName.Text, chkEnable.Checked, trigger, actions);
        }
    }
}