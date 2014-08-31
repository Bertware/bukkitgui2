// SixtySetup.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroMessageBox = MetroFramework.MetroMessageBox;

namespace Net.Bertware.Bukkitgui2.AddOn.SixtySetup
{
	/// <summary>
	///     A user friendly installer for any minecraft server which should get the minimalist job done under 60 seconds
	///     (download time not included)
	/// </summary>
	/// <remarks>
	///     SixtySetup should install any minecraft server easily.
	///     Create folder, download selected server
	///     Install plugins if available. Top 20 plugins or custom lists to be used as recommended plugin, full plugin support
	///     by implementing the default plugin manager
	///     Set the start settings
	///     Remote servers not supported since the lack of support for running a command on the remote console without SSH
	///     access (this would be too much access to ask from users)
	/// </remarks>
	public partial class SixtySetup : MetroForm
	{
		public SixtySetup()
		{
			InitializeComponent();
		}

		private void SixtySetup_Load(object sender, EventArgs e)
		{
			if (MetroMessageBox.Show(this, "Do you want to create a new server?" + Environment.NewLine +
			                               "Select YES in case you do not have a previous server you'd like to use." +
			                               Environment.NewLine +
			                               "Select NO in case you want to use the GUI with an existing server",
				"Create a new server?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) Close();

			SixtySetupServerDownload downloadControl = new SixtySetupServerDownload {Dock = DockStyle.Fill};
			downloadControl.ServerDownloaded += downloadControl_ServerDownloaded;
			pContainer.Controls.Add(downloadControl);
		}

		private void downloadControl_ServerDownloaded(object sender, EventArgs e)
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) (() => downloadControl_ServerDownloaded(sender, e)));
			}
			else
			{
				pContainer.Controls.Clear();
				SixtySetupSettings settingsControl = new SixtySetupSettings {Dock = DockStyle.Fill};
				settingsControl.SetupComplete += CloseForm;
				pContainer.Controls.Add(settingsControl);
			}
		}

		private void CloseForm(object sender, EventArgs e)
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) (() => CloseForm(sender, e)));
			}
			else
			{
				Close();
			}
		}
	}
}