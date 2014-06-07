// MainForm.cs in bukkitgui2/bukkitgui2
// Created 2014/01/30
// Last edited at 2014/06/07 20:24
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.AddOn;
using Net.Bertware.Bukkitgui2.AddOn.Starter;
using Net.Bertware.Bukkitgui2.Core;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Net.Bertware.Bukkitgui2.UI
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			Share.MainFormHandle = Handle; //Immediatly set the handle for form operations, tray issues, etc..

			// We need to load all the background stuff before we can start running the application
			// This can take a couple of seconds, so show a splashscreen
			// We have a splashscreen class that loads everything multithreaded, we just need it to show and wait until it's finished.
			SplashScreen splash = new SplashScreen(); // Create splashscreen
			splash.ShowDialog(); // Call ShowDialog(). This will show the splashscreen on foreground until it closes.

			// Start loading everything to the UI
			InitializeComponent();

			Logger.Log(LogLevel.Info, "mainform", "starting to load mainform UI");

			LoadTabs();
			Initialize();
		}

		private void Initialize()
		{
			MinecraftOutputHandler.OutputParsed += HandleOutput;
			ProcessHandler.ServerStarting += HandleServerStarting;
			ProcessHandler.ServerStarted += HandleServerStarted;
			ProcessHandler.ServerStopped += HandleServerStopped;
			ProcessHandler.ServerStopping += HandleServerStopping;
		}

		private void HandleServerStarting()
		{
			//suport for calls from other threads
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) (HandleServerStarting));
			}
			else
			{
				LblToolsMainServerState.Text = Locale.Tr("Starting...");
				ToolStripBtnStartStop.Enabled = false;
				ToolStripBtnStartStop.Text = Locale.Tr("Starting...");
			}
		}

		private void HandleServerStarted()
		{
			//suport for calls from other threads
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) (HandleServerStarted));
			}
			else
			{
				LblToolsMainServerState.Text = Locale.Tr("Server running");
				ToolStripBtnStartStop.Enabled = true;
				ToolStripBtnStartStop.Text = Locale.Tr("Stop");
			}
		}

		private void HandleServerStopping()
		{
			//suport for calls from other threads
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) (HandleServerStopping));
			}
			else
			{
				LblToolsMainServerState.Text = Locale.Tr("Stopping...");
				ToolStripBtnStartStop.Enabled = false;
				ToolStripBtnStartStop.Text = Locale.Tr("Stopping...");
			}
		}

		private void HandleServerStopped()
		{
			//suport for calls from other threads
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) (HandleServerStopped));
			}
			else
			{
				LblToolsMainServerState.Text = Locale.Tr("Stopped");

				ToolStripBtnStartStop.Enabled = true;
				ToolStripBtnStartStop.Text = Locale.Tr("Start");
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
				KeyValuePair<IAddon, UserControl> pair in AddonManager.TabsDictionary.OrderBy(i => GetTabDisplayId(i.Key.Name)))
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
				case "playerlist":
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
					Starter starter = (Starter) AddonManager.GetRequiredAddon(RequiredAddon.Starter);
					// Get the starter addon
					starter.LaunchServerFromTab(); // Launch with tab settings
				}
			}
		}
	}
}