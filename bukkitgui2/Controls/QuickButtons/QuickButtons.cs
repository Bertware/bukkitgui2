using System;

using System.Windows.Forms;
using Bukkitgui2.Core;
using Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Bukkitgui2.Controls.QuickButtons
{
	public partial class QuickButtons : UserControl
	{
		public QuickButtons()
		{
			InitializeComponent();
			ProcessHandler.ServerStarting += HandleServerStarting;
			ProcessHandler.ServerStarted += HandleServerStarted;
			ProcessHandler.ServerStopped += HandleServerStopped;
			ProcessHandler.ServerStopping += HandleServerStopping;
		}

		private void HandleServerStarting()
		{
			btnStartStop.Enabled = false;
			btnStartStop.Text = Locale.Tr("Starting...");
		}

		private void HandleServerStarted()
		{
			btnStartStop.Enabled = true;
			btnStartStop.Text = Locale.Tr("Stop");
		}

		private void HandleServerStopping()
		{
			btnStartStop.Enabled = false;
			btnStartStop.Text = Locale.Tr("Stopping...");
		}

		private void HandleServerStopped()
		{
			btnStartStop.Enabled = true;
			btnStartStop.Text = Locale.Tr("Start");
		}

		private void btnStartStop_Click(object sender, EventArgs e)
		{
			if (ProcessHandler.IsRunning)
			{
				ProcessHandler.StopServer();
			}
			else
			{
				// TODO: code to start server
			}
		}
	}
}
