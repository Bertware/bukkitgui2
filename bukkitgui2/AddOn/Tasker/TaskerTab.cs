// TaskerTab.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/07/13 14:01
// ©Bertware, visit http://bertware.net

using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.AddOn.Tasker.TaskerDialog.TaskerUI;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker
{
	public partial class TaskerTab : UserControl, IAddonTab
	{
		public TaskerTab()
		{
			InitializeComponent();
		}

		public IAddon ParentAddon { get; set; }

		private void btnNew_Click(object sender, System.EventArgs e)
		{
			TaskEditor editor = new TaskEditor();
			editor.ShowDialog();
		}
	}
}