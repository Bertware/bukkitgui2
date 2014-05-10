using System.Collections.Generic;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.AddOn;
using Net.Bertware.Bukkitgui2.AddOn.Backup;
using Net.Bertware.Bukkitgui2.AddOn.Console;
using Net.Bertware.Bukkitgui2.AddOn.Editor;
using Net.Bertware.Bukkitgui2.AddOn.Forwarder;
using Net.Bertware.Bukkitgui2.AddOn.Permissions;
using Net.Bertware.Bukkitgui2.AddOn.PlayerList;
using Net.Bertware.Bukkitgui2.AddOn.Plugins;
using Net.Bertware.Bukkitgui2.AddOn.Settings;
using Net.Bertware.Bukkitgui2.AddOn.Starter;
using Net.Bertware.Bukkitgui2.AddOn.Tasker;
using Net.Bertware.Bukkitgui2.Core;
using Net.Bertware.Bukkitgui2.Core.Configuration;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Net.Bertware.Bukkitgui2.UI
{
	public partial class MainForm : Form
	{
		private const string CfgIdent = "mainform";

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
		///     Dictionary to store all loaded addons, by [Name, IAddon]
		/// </summary>
		private Dictionary<string, IAddon> _addonsDictionary;

		/// <summary>
		///     Load all tabpages to the mainform
		/// </summary>
		private void LoadTabs()
		{
			// construct the dictionary that we'll use to store addons during runtime
			_addonsDictionary = new Dictionary<string, IAddon>();

			//Create and store a list with the loaded tabs, then load them to the UI.
			// max 16 addons for now
			IAddon[] addonsToLoad = new IAddon[16];

			byte i = 0;

			//This tab can't be disabled
			//if (cfg.ReadInt(CFG_IDENT, "show_console", 1) == 1)
			//{
			addonsToLoad[i] = new Console();
			i++;
			//}

			if (Config.ReadInt(CfgIdent, "show_playerlist", 1) == 1)
			{
				addonsToLoad[i] = new PlayerList();
				i++;
			}

			//This tab can't be disabled
			//if (cfg.ReadInt(CFG_IDENT, "show_starter", 1) == 1)
			//{
			addonsToLoad[i] = new Starter();
			i++;
			//}

			if (Config.ReadInt(CfgIdent, "show_tasker", 1) == 1)
			{
				addonsToLoad[i] = new Tasker();
				i++;
			}

			if (Config.ReadInt(CfgIdent, "show_plugins", 1) == 1)
			{
				addonsToLoad[i] = new Plugins();
				i++;
			}

			if (Config.ReadInt(CfgIdent, "show_permissions", 1) == 1)
			{
				addonsToLoad[i] = new Permissions();
				i++;
			}

			if (Config.ReadInt(CfgIdent, "show_editor", 1) == 1)
			{
				addonsToLoad[i] = new Editor();
				i++;
			}

			if (Config.ReadInt(CfgIdent, "show_backup", 1) == 1)
			{
				addonsToLoad[i] = new Backup();
				i++;
			}

			if (Config.ReadInt(CfgIdent, "show_forwarder", 1) == 1)
			{
				addonsToLoad[i] = new Forwarder();
				i++;
			}

			//This tab can't be disabled
			//if (cfg.ReadInt(CFG_IDENT, "show_settings", 1) == 1)
			//{
			addonsToLoad[i] = new Settings();
			i++;
			//}

			// Loop through all addons in the array
			for (byte j = 0; j <= i; j++)
			{
				if (addonsToLoad[j] == null)
				{
					continue; //if addon not set, go on to the next one
				}

				Logger.Log(LogLevel.Info, "mainform", "loading addon", addonsToLoad[j].Name);

				addonsToLoad[j].Initialize(); // initialize the addon
				Logger.Log(LogLevel.Info, "mainform", "initialized addon", addonsToLoad[j].Name);

				// The addon has initialized without problems. Add it to the dictionary so it can be used by other components too
				_addonsDictionary.Add(addonsToLoad[j].Name, addonsToLoad[j]);

				// If this addon doesn't have a tabpage, or if the tabpage is missing, go to the next addon
				if (!addonsToLoad[j].HasTab || addonsToLoad[j].TabPage == null)
				{
					continue; // If no tabpage is available, skip loading
				}

				// Create a new tabpage. We'll dock the control to fill the tabpage
				TabPage tp = new TabPage(addonsToLoad[j].Name);

				// Add and dock the control
				tp.Controls.Add(addonsToLoad[j].TabPage);
				tp.Controls[0].Dock = DockStyle.Fill;

				// Add the tabpage
				TabCtrlAddons.TabPages.Add(tp);

				Logger.Log(LogLevel.Info, "mainform", "added addon tabpage", addonsToLoad[j].Name);
			}
		}

		/// <summary>
		///     Get the instance of a loaded addon
		/// </summary>
		/// <param name="name">The name of the addon</param>
		/// <returns>Returns the addon if possible, null if the addon isn't loaded</returns>
		public IAddon GetAddon(string name)
		{
			return _addonsDictionary.ContainsKey(name) ? _addonsDictionary[name] : null;
		}

		/// <summary>
		///     Get the instance of a loaded core addon
		/// </summary>
		/// <param name="addon">The addon to load</param>
		/// <returns>Returns the addon if possible, null if the addon isn't loaded</returns>
		internal IAddon GetRequiredAddon(RequiredAddon addon)
		{
			return _addonsDictionary.ContainsKey(addon.ToString())
				? _addonsDictionary[addon.ToString()]
				: null;
		}
	}
}