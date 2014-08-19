// UiLauncher.cs in bukkitgui2/bukkitgui2
// Created 2014/08/19
// Last edited at 2014/08/19 13:43
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.UI;

namespace Net.Bertware.Bukkitgui2
{
	/// <summary>
	///     Workaround, since we can't run a metroform from program.cs (due to dynamic dll loading)
	/// </summary>
	public partial class UiLauncher : Form
	{
		public UiLauncher()
		{
			InitializeComponent();
			Visible = false;
			MainForm form = new MainForm();
			form.Closed += form_Closed;
			form.ShowForm();
		}

		private void form_Closed(object sender, EventArgs e)
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) (() => form_Closed(sender, e)));
			}
			else
			{
				Close();
			}
		}
	}
}