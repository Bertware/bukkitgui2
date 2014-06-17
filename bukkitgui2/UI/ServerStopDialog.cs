using System;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Net.Bertware.Bukkitgui2.UI
{
	public partial class ServerStopDialog : Form
	{
		public ServerStopDialog()
		{
			InitializeComponent();
		}


		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;

		}

		private void ServerStopDialog_Load(object sender, EventArgs e)
		{
			if (ProcessHandler.CurrentState == ServerState.Stopped)
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			ProcessHandler.ServerStopped += Return;
		}

		private void Return()
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new MethodInvoker(Return));
			}
			else
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
	}
}
