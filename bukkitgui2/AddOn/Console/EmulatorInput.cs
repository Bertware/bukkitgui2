// EmulatorInput.cs in bukkitgui2/bukkitgui2
// Created 2014/09/04
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;
using MetroMessageBox = MetroFramework.MetroMessageBox;

namespace Net.Bertware.Bukkitgui2.AddOn.Console
{
	public partial class EmulatorInput : MetroForm
	{
		public EmulatorInput()
		{
			InitializeComponent();
		}

		private void btnEmulate_Click(object sender, EventArgs e)
		{
			if (!ProcessHandler.IsRunning)
			{
				MetroMessageBox.Show(this, "The server has to be running in order to emulate output!", "Server not running",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			foreach (string line in txtLog.Text.Split(Environment.NewLine.ToCharArray()[0]))
			{
				MinecraftOutputHandler.HandleOutput(ProcessHandler.Server, line);
			}
		}
	}
}