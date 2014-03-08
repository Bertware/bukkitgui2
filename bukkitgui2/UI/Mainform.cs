using System.Collections.Generic;
using System.Windows.Forms;
using Bukkitgui2.AddOn;
using Bukkitgui2.Core.Configuration;
using Bukkitgui2.Core.Logging;

namespace Bukkitgui2.UI
{
	public partial class MainForm : Form
	{
		private const string CfgIdent = "mainform";

		public MainForm()
		{
			Core.Share.MainFormHandle = Handle; //Immediatly set the handle for form operations, tray issues, etc..

			// We need to load all the background stuff before we can start running the application
			// This can take a couple of seconds, so show a splashscreen
			// We have a splashscreen class that loads everything multithreaded, we just need it to show and wait until it's finished.
			var splash = new SplashScreen(); // Create splashscreen
			splash.ShowDialog(); // Call ShowDialog(). This will show the splashscreen on foreground until it closes.

			// Start loading everything to the UI
			InitializeComponent();

			Logger.Log(LogLevel.Info, "mainform", "starting to load mainform UI");

			LoadTabs();
		}

		/// <summary>
		/// Dictionary to store all loaded addons, by [Name, IAddon]
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
			IAddon[] addonsToLoad = new AddOn.IAddon[16];

			byte i = 0;

			//This tab can't be disabled
			//if (cfg.ReadInt(CFG_IDENT, "show_console", 1) == 1)
			//{
			addonsToLoad[i] = new AddOn.Console.Console();
			i++;
			//}

			if (Config.ReadInt(CfgIdent, "show_playerlist", 1) == 1)
			{
				addonsToLoad[i] = new AddOn.PlayerList.PlayerList();
				i++;
			}

			//This tab can't be disabled
			//if (cfg.ReadInt(CFG_IDENT, "show_starter", 1) == 1)
			//{
			addonsToLoad[i] = new AddOn.Starter.Starter();
			i++;
			//}

			if (Config.ReadInt(CfgIdent, "show_tasker", 1) == 1)
			{
				addonsToLoad[i] = new AddOn.Tasker.Tasker();
				i++;
			}

			if (Config.ReadInt(CfgIdent, "show_plugins", 1) == 1)
			{
				addonsToLoad[i] = new AddOn.Plugins.Plugins();
				i++;
			}

			if (Config.ReadInt(CfgIdent, "show_permissions", 1) == 1)
			{
				addonsToLoad[i] = new AddOn.Permissions.Permissions();
				i++;
			}

			if (Config.ReadInt(CfgIdent, "show_editor", 1) == 1)
			{
				addonsToLoad[i] = new AddOn.Editor.Editor();
				i++;
			}

			if (Config.ReadInt(CfgIdent, "show_backup", 1) == 1)
			{
				addonsToLoad[i] = new AddOn.Backup.Backup();
				i++;
			}

			if (Config.ReadInt(CfgIdent, "show_forwarder", 1) == 1)
			{
				addonsToLoad[i] = new AddOn.Forwarder.Forwarder();
				i++;
			}

			//This tab can't be disabled
			//if (cfg.ReadInt(CFG_IDENT, "show_settings", 1) == 1)
			//{
			addonsToLoad[i] = new AddOn.Settings.Settings();
			i++;
			//}


			// Loop through all addons in the array
			for (byte j = 0; j <= i; j++)
			{
				if (addonsToLoad[j] == null) continue; //if addon not set, go on to the next one

				Logger.Log(LogLevel.Info, "mainform", "loading addon", addonsToLoad[j].Name);

				addonsToLoad[j].Initialize(); // initialize the addon
				Logger.Log(LogLevel.Info, "mainform", "initialized addon", addonsToLoad[j].Name);

				// The addon has initialized without problems. Add it to the dictionary so it can be used by other components too
				_addonsDictionary.Add(addonsToLoad[j].Name, addonsToLoad[j]);

				// If this addon doesn't have a tabpage, or if the tabpage is missing, go to the next addon
				if (!addonsToLoad[j].HasTab || addonsToLoad[j].TabPage == null)
					continue; // If no tabpage is available, skip loading

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
		/// Get the instance of a loaded addon
		/// </summary>
		/// <param name="name">The name of the addon</param>
		/// <returns>Returns the addon if possible, null if the addon isn't loaded</returns>
		public IAddon GetAddon(string name)
		{
			return _addonsDictionary.ContainsKey(name) ? _addonsDictionary[name] : null;
		}

		/// <summary>
		/// Get the instance of a loaded core addon
		/// </summary>
		/// <param name="addon">The addon to load</param>
		/// <returns>Returns the addon if possible, null if the addon isn't loaded</returns>
		internal IAddon GetRequiredAddon(RequiredAddon addon)
		{
			return _addonsDictionary.ContainsKey(addon.ToString()) ? _addonsDictionary[addon.ToString()] : null;
		}
	}
}