// TaskEditor.cs in bukkitgui2/bukkitgui2
// Created 2014/06/24
// Last edited at 2014/07/13 14:01
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.AddOn.Tasker.Trigger;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.TaskerDialog.TaskerUI
{
	public partial class TaskEditor : Form
	{

		private readonly List<ITrigger> _triggers = Core.Util.DynamicModuleLoader.GetClassesOfType<ITrigger>("Net.Bertware.Bukkitgui2.AddOn.Tasker.Trigger");
		private ITrigger _selectedTrigger;

		public TaskEditor()
		{
			InitializeComponent();
			PopulateUi();
		}

		private void PopulateUi()
		{
			cbTrigger.Items.Clear();
			foreach (ITrigger trigger in _triggers)
			{
				cbTrigger.Items.Add(trigger.Name);
			}
		}

		private void cbTrigger_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			foreach (ITrigger trigger in _triggers)
			{
				if (cbTrigger.SelectedItem.ToString().Equals(trigger.Name)) _selectedTrigger = trigger;
			}
		}

		private void txtTriggerParam_TextChanged(object sender, System.EventArgs e)
		{
			if (_selectedTrigger == null) return;
			
			if (_selectedTrigger.ValidateInput(txtTriggerParam.Text) == true)
			{
				errorProvider.SetError(txtTriggerParam, "");
			} else {
				errorProvider.SetError(txtTriggerParam, "Invalid parameter!" + Environment.NewLine +  _selectedTrigger.ParameterDescription);
			}
		}

		

	}
}