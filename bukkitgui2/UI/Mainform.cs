// MainForm.cs in bukkitgui2/bukkitgui2
// Created 2014/01/30
// Last edited at 2014/08/22 12:19
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using Net.Bertware.Bukkitgui2.AddOn;
using Net.Bertware.Bukkitgui2.AddOn.Starter;
using Net.Bertware.Bukkitgui2.Core;
using Net.Bertware.Bukkitgui2.Core.Configuration;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.Core.Translation;
using Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Net.Bertware.Bukkitgui2.UI
{
	public partial class MainForm : MetroForm
	{
		public static MainForm Reference;

		public readonly string FormTitle = Share.AssemblyName + " (v" + Share.AssemblyVersion + ")";


		public MainForm()
		{
			Reference = this;
			Share.MainFormHandle = Handle; //Immediatly set the handle for form operations, tray issues, etc..
			Visible = false;

			// Should the splash screen be shown?
			bool showSplash = !Environment.GetCommandLineArgs().Contains("-nosplash");
			bool showUi = !Environment.GetCommandLineArgs().Contains("-minimized");
			if (!showUi) showSplash = false;

			if (showSplash)
			{
				new Thread(() => new SplashScreen().ShowDialog()).Start();
			}
			
			// ____________ initializations here ____________ //
			// 
			Initialize();
			Share.Initialize();

			// ____________ end  initializations ____________ //

			Logger.Log(LogLevel.Info, "mainform", "starting to load mainform UI");

			// Start loading everything to the UI
			InitializeComponent();

			// Do this after InitializeComponent() because we need access to the controls
			// TODO: fix plugin manager locking up the UI
			LoadTabs();

			if (showSplash)
			{
				SplashScreen.Reference.SafeFormClose();
			}

			if (showUi)
			{
				// Visible and to front
				Visible = true;
				this.TopLevel = true;
				BringToFront();
				FocusMe();
				
			}
			else
			{
				// If we're starting minimized, we have to make sure the tray is enabled
				Config.WriteBool("notifications", "enabled", false);
				Config.WriteBool("notifications", "always", false);
			}
		}


		public void ShowForm()
		{
			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(ShowForm));
			}
			else
			{
				Show();
			}
		}

		private void Initialize()
		{
			MinecraftOutputHandler.OutputParsed += HandleOutput;
			ProcessHandler.ServerStatusChanged += HandleServerStatusChange;
			Text = FormTitle;
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
						LblToolsMainServerState.Text = Locale.Tr("Starting...");
						ToolStripBtnStartStop.Enabled = false;
						ToolStripBtnStartStop.Text = Locale.Tr("Starting...");
						Text = FormTitle + Locale.Tr("Starting...");
						SpinServerState.Spinning = true;
						SpinServerState.Speed = 7;
						SpinServerState.Value = 15;
						break;
					case ServerState.Running:
						LblToolsMainServerState.Text = Locale.Tr("Server running");
						ToolStripBtnStartStop.Enabled = true;
						ToolStripBtnStartStop.Text = Locale.Tr("Stop");
						Text = FormTitle + " - " + Locale.Tr("Server running");
						SpinServerState.Spinning = true;
						SpinServerState.Speed = 1;
						SpinServerState.Value = 100;
						break;

					case ServerState.Stopping:
						LblToolsMainServerState.Text = Locale.Tr("Stopping...");
						ToolStripBtnStartStop.Enabled = false;
						ToolStripBtnStartStop.Text = Locale.Tr("Stopping...");
						Text = FormTitle + " - " + Locale.Tr("Server stopping");
						SpinServerState.Spinning = true;
						SpinServerState.Speed = 7;
						SpinServerState.Value = 15;
						break;
					case ServerState.Stopped:
						LblToolsMainServerState.Text = Locale.Tr("Stopped");

						ToolStripBtnStartStop.Enabled = true;
						ToolStripBtnStartStop.Text = Locale.Tr("Start");
						Text = FormTitle + " - " + Locale.Tr("Server stopped");

						SpinServerState.Spinning = false;
						SpinServerState.Speed = 1;
						SpinServerState.Value = 100;
						break;
				}
			}
		}


		/// <summary>
		///     Handle output from the server and print it to the bottom of the screen
		/// </summary>
		/// <param name="text"> The text that was parsed</param>
		/// <param name="result">Result of the parse operation</param>
		private void HandleOutput(string text, OutputParseResult result)
		{
			//suport for calls from other threads
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) (() => HandleOutput(text, result)));
			}
			else
			{
				LblToolsMainServerOutput.Text = result.Message;
			}
		}

		/// <summary>
		///     Load all tabpages to the mainform
		/// </summary>
		private void LoadTabs()
		{
			if (! AddonManager.AddonsLoaded) AddonManager.LoadAddons();

			foreach (
				KeyValuePair<IAddon, UserControl> pair in
					AddonManager.TabsDictionary.OrderBy(i => GetTabDisplayId(i.Key.Name)))
			{
				// Create a new tabpage. We'll dock the control to fill the tabpage
				TabPage tp = new TabPage(pair.Key.Name);

				// Add and dock the control
				tp.Controls.Add(pair.Value);
				tp.Controls[0].Dock = DockStyle.Fill;

				// Add the tabpage
				TabCtrlAddons.TabPages.Add(tp);

				Logger.Log(LogLevel.Info, "mainform", "added addon tabpage", pair.Key.Name);
			}
			AddonManager.GetRequiredAddon(RequiredAddon.Settings).Initialize();
		}

		/// <summary>
		///     Get the priority of each tab, lower values will show first
		/// </summary>
		/// <param name="tab">name of the addon showing this tab</param>
		/// <returns></returns>
		private static int GetTabDisplayId(string tab)
		{
			switch (tab.ToLower())
			{
				case "console":
					return 0;
				case "players":
					return 1;
				case "starter":
					return 2;
				case "tasker":
					return 3;
				case "plugins":
					return 4;
				case "editor":
					return 5;
				case "permissions":
					return 6;
				case "forwarder":
					return 7;
				case "backup":
					return 8;
				case "settings":
					return 128;
				default:
					return 64;
			}
		}


		private void ToolStripBtnStartStop_Click(object sender, EventArgs e)
		{
			//suport for calls from other threads
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) (() => ToolStripBtnStartStop_Click(sender, e)));
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


		private void ToolStripBtnRestart_Click(object sender, EventArgs e)
		{
			//suport for calls from other threads
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) (() => ToolStripBtnStartStop_Click(sender, e)));
			}
			else
			{
				Starter.RestartServer(); // Launch with tab settings
			}
		}

		/// <summary>
		///     Check if a server is still running before closing the GUI
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!ProcessHandler.IsRunning) return;

			if (ProcessHandler.CurrentState == ServerState.Starting ||
			    ProcessHandler.CurrentState == ServerState.Running)
			{
				// if windows is shutting down or app is killed from task manager
				if (e.CloseReason == CloseReason.TaskManagerClosing || e.CloseReason == CloseReason.WindowsShutDown)
				{
					// make sure to stop server to prevent data loss
					Starter.StopServer();
					return;
				}
				// ask what to do
				DialogResult result = MessageBox.Show(
					Translator.Tr(
						"The server is still running. Closing it without a proper stop might result in data loss. Send stop command first?"),
					Translator.Tr("Server still running"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

				// execute a correct action based upon user input
				switch (result)
				{
					case DialogResult.Yes:
						ProcessHandler.ServerStopped += SafeFormClose;
						Starter.StopServer();
						e.Cancel = true;
						break;
					case DialogResult.No:
						// close form
						break;
					case DialogResult.Cancel:
						e.Cancel = true;
						break;
				}
			}
			else
			{
				// wait for server to stop
				ServerStopDialog serverStopDialog = new ServerStopDialog();
				DialogResult result = serverStopDialog.ShowDialog();
				// if waiting cancelled, don't shutdown
				if (result == DialogResult.Cancel) e.Cancel = true;
			}
		}

		/// <summary>
		///     Close this form thread-safe
		/// </summary>
		private void SafeFormClose()
		{
			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(SafeFormClose));
			}
			else
			{
				Close();
			}
		}

		private void ToggleTheme_CheckedChanged(object sender, EventArgs e)
		{
			metroStyleManager.Theme = (ToggleTheme.Checked) ? MetroThemeStyle.Dark : MetroThemeStyle.Light;
			Theme = metroStyleManager.Theme;
			Refresh();
		}
	}
}