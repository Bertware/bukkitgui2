using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.AddOn.Tasker.Action;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.TaskerDialog
{
	public partial class ActionSelector : UserControl
	{
		private IAction _selectedAction;
		private readonly List<IAction> _actions = Core.Util.DynamicModuleLoader.GetClassesOfType<IAction>("Net.Bertware.Bukkitgui2.AddOn.Tasker.Action");

		public ActionSelector()
		{
			InitializeComponent();
			gbAction.Text = "Action";
			PopulateUi();
		}

		public ActionSelector(int i)
		{
			InitializeComponent();
			gbAction.Text = "Action " +i;
			PopulateUi();
		}

		private void PopulateUi()
		{
			cbAction.Items.Clear();
			foreach (IAction action in _actions)
			{
				cbAction.Items.Add(action.Name);
			}
		}

		private void cbaction_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			foreach (IAction action in _actions)
			{
				if (cbAction.SelectedItem.ToString().Equals(action.Name)) _selectedAction = action;
			}
		}

		private void txtactionParam_TextChanged(object sender, System.EventArgs e)
		{
			if (_selectedAction == null) return;

			if (_selectedAction.ValidateInput(txtActionParameters.Text) == true)
			{
				errorProvider.SetError(txtActionParameters, "");
			}
			else
			{
				errorProvider.SetError(txtActionParameters, "Invalid parameter!" + Environment.NewLine + _selectedAction.ParameterDescription);
			}
		}
	}
}
