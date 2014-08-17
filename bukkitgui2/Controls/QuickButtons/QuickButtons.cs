// QuickButtons.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/08/17 11:19
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.AddOn.Starter;
using Net.Bertware.Bukkitgui2.Core;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Net.Bertware.Bukkitgui2.Controls.QuickButtons
{
	public partial class QuickButtons : UserControl
	{
		public QuickButtons()
		{
			InitializeComponent();
			ProcessHandler.ServerStatusChanged += HandleServerStatusChange;
		}

		private void HandleServerStatusChange(ServerState currentState)
		{
			//suport for calls from other threads
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) (() => HandleServerStatusChange(currentState)));
			}
			else
			{
				switch (currentState)
				{
					case ServerState.Starting:
						btnStartStop.Enabled = false;
						btnStartStop.Text = Locale.Tr("Starting...");
						break;
					case ServerState.Running:
						btnStartStop.Enabled = true;
						btnStartStop.Text = Locale.Tr("Stop");
						break;
					case ServerState.Stopping:
						btnStartStop.Enabled = false;
						btnStartStop.Text = Locale.Tr("Stopping...");
						break;
					case ServerState.Stopped:
						btnStartStop.Enabled = true;
						btnStartStop.Text = Locale.Tr("Start");
						break;
				}
			}
		}

		private void BtnStartStopClick(object sender, EventArgs e)
		{
			//suport for calls from other threads
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) (() => BtnStartStopClick(sender, e)));
			}
			else
			{
				if (ProcessHandler.IsRunning)
				{
					ProcessHandler.StopServer();
				}
				else
				{
					Starter.StartServer(); // Launch with tab settings
				}
			}
		}

		private void btnCustom_Click(object sender, EventArgs e)
		{
			Starter.KillServer();
		}
	}
}