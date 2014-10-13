// ActionSelector.cs in bukkitgui2/bukkitgui2
// Created 2014/08/10
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.AddOn.Tasker.Action;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.TaskerUI
{
    public partial class ActionSelector : MetroUserControl
    {
        private IAction _selectedAction;


        public ActionSelector()
        {
            InitializeComponent();
            gbAction.Text = "Action";
            PopulateUi();
        }

        public ActionSelector(int i)
        {
            InitializeComponent();
            gbAction.Text = "Action " + i;
            PopulateUi();
        }

        private void PopulateUi()
        {
            cbAction.Items.Clear();
            foreach (IAction action in Task.AllActions)
            {
                cbAction.Items.Add(action.Name);
            }
        }

        private void cbaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (IAction action in Task.AllActions)
            {
                if (cbAction.SelectedItem.ToString().Equals(action.Name)) _selectedAction = action;
            }
            if (_selectedAction != null)
            {
                lblActionDescription.Text = _selectedAction.ParameterDescription;
            }
        }

        private void txtactionParam_TextChanged(object sender, EventArgs e)
        {
            if (_selectedAction == null) return;

            if (_selectedAction.ValidateInput(txtActionParameters.Text))
            {
                errorProvider.SetError(txtActionParameters, "");
            }
            else
            {
                errorProvider.SetError(txtActionParameters,
                    "Invalid parameter!" + Environment.NewLine + _selectedAction.ParameterDescription);
            }
        }

        /// <summary>
        ///     Get the action based upon the input
        /// </summary>
        /// <returns></returns>
        public IAction GetAction()
        {
            IAction action = _selectedAction;
            action.Parameters = txtActionParameters.Text;
            return action;
        }

        public void SetAction(IAction action)
        {
            for (int i = 0; i < cbAction.Items.Count; i++)
            {
                if (cbAction.Items[i].ToString().Equals(action.Name)) cbAction.SelectedIndex = i;
            }
            txtActionParameters.Text = action.Parameters;
        }

        private void btnDeleteAction_Click(object sender, EventArgs e)
        {
            this.DestroyHandle();
            this.Dispose();
        }
    }
}