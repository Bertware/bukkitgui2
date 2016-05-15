// MainForm.cs in bukkitgui2/bukkitgui2
// Created 2014/01/30
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using MetroFramework.Forms;
using Net.Bertware.Bukkitgui2.AddOn;
using Net.Bertware.Bukkitgui2.AddOn.Starter;
using Net.Bertware.Bukkitgui2.Core;
using Net.Bertware.Bukkitgui2.Core.Configuration;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ServerConfig;
using MetroMessageBox = MetroFramework.MetroMessageBox;

namespace Net.Bertware.Bukkitgui2.UI
{
	public partial class MainForm : MetroForm
	{
		public static MainForm Reference;

		public readonly string FormTitle = Share.AssemblyName + " (v" + Share.AssemblyVersion + ")";
		private string _serverName = "";

		public MainForm()
		{
			Reference = this;
			Share.MainFormHandle = Handle; //Immediatly set the handle for form operations, tray issues, etc..
			Visible = false;

			// Should the splash screen be shown?
			bool showSplash = !Environment.GetCommandLineArgs().Contains("-nosplash");
			bool showUi = !Environment.GetCommandLineArgs().Contains("-minimized");
			bool start = Environment.GetCommandLineArgs().Contains("-start");

			if (!showUi) showSplash = false;

			if (showSplash)
			{
				new Thread(() => new SplashScreen().ShowDialog()) {Name = "Splashscreen_show"}.Start();
			}


			// ____________ initializations here ____________ //
			// 

			Share.Initialize();

			Logger.Log(LogLevel.Info, "mainform", "starting to load mainform UI");
			// Start loading everything to the UI
			InitializeComponent();
			Logger.Log(LogLevel.Info, "mainform", "loaded mainform UI");

			Logger.Log(LogLevel.Info, "mainform", "loading application");
			Initialize();

			// ____________ end  initializations ____________ //


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
				TopLevel = true;
				BringToFront();
				FocusMe();
			}
			else
			{
				// If we're starting minimized, we have to make sure the tray is enabled
				Config.WriteBool("notifications", "enabled", true);
			}
			Logger.Log(LogLevel.Info, "mainform", "Finished loading");

			// ! only for advanced users
			if (start) Starter.StartServerAutomated();
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
			if (string.IsNullOrEmpty(_serverName))
				_serverName = ServerProperties.GetServerSetting("server-name");
			if (string.IsNullOrEmpty(_serverName))
				_serverName = ServerProperties.GetServerSetting("motd");
			if (_serverName == null) _serverName = ""; //prevent errors
			Text = FormTitle + " - " + _serverName;
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
					// TODO: fix title text not adjusting (Metro UI bug)
					case ServerState.Starting:
						LblToolsMainServerState.Text = Locale.Tr("Starting...");
						ToolStripBtnStartStop.Enabled = false;
						ToolStripBtnStartStop.Text = Locale.Tr("Starting...");

						SpinServerState.Spinning = true;
						SpinServerState.Speed = 7;
						SpinServerState.Value = 15;
						break;
					case ServerState.Running:
						LblToolsMainServerState.Text = Locale.Tr("Server running");
						ToolStripBtnStartStop.Enabled = true;
						ToolStripBtnStartStop.Text = Locale.Tr("Stop");

						SpinServerState.Spinning = true;
						SpinServerState.Speed = 1;
						SpinServerState.Value = 100;
						break;

					case ServerState.Stopping:
						LblToolsMainServerState.Text = Locale.Tr("Stopping...");
						ToolStripBtnStartStop.Enabled = false;
						ToolStripBtnStartStop.Text = Locale.Tr("Stopping...");

						SpinServerState.Spinning = true;
						SpinServerState.Speed = 7;
						SpinServerState.Value = 15;
						break;
					case ServerState.Stopped:
						LblToolsMainServerState.Text = Locale.Tr("Stopped");
						ToolStripBtnStartStop.Enabled = true;
						ToolStripBtnStartStop.Text = Locale.Tr("Start");

						SpinServerState.Spinning = false;
						SpinServerState.Speed = 1;
						SpinServerState.Value = 100;
						break;
				}
				UpdateTitle();
			}
		}

		public void UpdateTitle()
		{
			//suport for calls from other threads
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) (UpdateTitle));
			}
			else
			{
				_serverName = ServerProperties.GetServerSetting("motd");
				if (_serverName == null) _serverName = ""; //prevent errors

				switch (ProcessHandler.CurrentState)
				{
					// TODO: fix title text not adjusting (Metro UI bug)
					case ServerState.Starting:
						Text = FormTitle + " - " + _serverName + " - " + Locale.Tr("Starting...");
						SpinServerState.Spinning = true;
						break;
					case ServerState.Running:
						Text = FormTitle + " - " + _serverName + " - " + Locale.Tr("Server running");
						break;
					case ServerState.Stopping:
						Text = FormTitle + " - " + _serverName + " - " + Locale.Tr("Server stopping");
						break;
					case ServerState.Stopped:
						Text = FormTitle + " - " + _serverName + " - " + Locale.Tr("Server stopped");
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
			if (!AddonManager.AddonsLoaded) AddonManager.LoadAddons();

			foreach (
				KeyValuePair<IAddon, UserControl> pair in
					AddonManager.TabsDictionary.OrderBy(i => GetTabDisplayId(i.Key.Name)))
			{
				// Create a new tabpage. We'll dock the control to fill the tabpage
				TabPage tp = new TabPage(pair.Key.Name) {Name = pair.Key.Name};
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
					return 8;
				case "starter":
					return 16;
				case "issues":
					return 17;
				case "tasker":
					return 24;
				case "plugins":
					return 32;
				case "editor":
					return 40;
				case "permissions":
					return 48;
				case "forwarder":
					return 56;
				case "backup":
					return 64;
				case "settings":
					return 256;
				default:
					return 128;
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
		///     Go to a certain tabpage
		/// </summary>
		/// <param name="name">The name of the tab to go to. Case insensitive.</param>
		public void GoToTab(string name)
		{
			foreach (TabPage tab in TabCtrlAddons.TabPages)
			{
				if (tab.Text.ToLower().Equals(name)) TabCtrlAddons.SelectTab(tab);
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
					ProcessHandler.StopServer();
					return;
				}
				// ask what to do
				DialogResult result = MetroMessageBox.Show(this,
					Locale.Tr(
						"The server is still running. Closing it without a proper stop might result in data loss. Send stop command first?"),
					Locale.Tr("Server still running"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

				// execute a correct action based upon user input
				switch (result)
				{
					case DialogResult.Yes:
						ProcessHandler.ServerStopped += SafeFormClose;
						ProcessHandler.StopServer();
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
	}
}