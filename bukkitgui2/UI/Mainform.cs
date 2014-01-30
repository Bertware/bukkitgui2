using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using bukkitgui2.Core.Logging;
using System.Text;
using System.Windows.Forms;

namespace bukkitgui2.UI
{
    public partial class MainForm : Form
    {
		private const string CFG_IDENT = "mainform";

		private Core.Configuration.IConfig cfg = null;
		private Core.Logging.ILogger logger = null;

        public MainForm()
        {

            Core.Share.MainFormHandle = this.Handle; //Immediatly set the handle for form operations, tray issues, etc...

            // We need to load all the background stuff before we can start running the application
            // This can take a couple of seconds, so show a splashscreen
            // We have a splashscreen class that loads everything multithreaded, we just need it to show and wait until it's finished.
            SplashScreen Splash = new SplashScreen(); // Create splashscreen
            Splash.ShowDialog(); // Call ShowDialog(). This will show the splashscreen on foreground until it closes.

			cfg = Core.Share.Config;
			logger = Core.Share.Logger;

            // Start loading everything to the UI
            InitializeComponent();

			logger.Log(LogLevel.Info, "mainform", "starting to load mainform UI");

			LoadTabs();
        }

		
		private AddOn.IAddon[] Addons ;
		
		/// <summary>
		/// Load all tabpages to the mainform
		/// </summary>
		private void LoadTabs()
		{
			//Create and store a list with the loaded tabs, then load them to the UI.

			Addons=new AddOn.IAddon[16];
			
			byte i = 0;

			//This tab can't be disabled
			//if (cfg.ReadInt(CFG_IDENT, "show_console", 1) == 1)
			//{
			Addons[i] = new AddOn.Console.Console();
			i++;
			//}

			if (cfg.ReadInt(CFG_IDENT,"show_players",1) == 1)
			{
				Addons[i] = new AddOn.Playerlist.PlayerList();
				i++;
			}

			//This tab can't be disabled
			//if (cfg.ReadInt(CFG_IDENT, "show_starter", 1) == 1)
			//{
				Addons[i] = new AddOn.Starter.Starter();
				i++;
			//}

			if (cfg.ReadInt(CFG_IDENT, "show_tasker", 1) == 1)
			{
				Addons[i] = new AddOn.Tasker.Tasker();
				i++;
			}

			if (cfg.ReadInt(CFG_IDENT, "show_plugins", 1) == 1)
			{
				Addons[i] = new AddOn.Plugins.Plugins();
				i++;
			}

			if (cfg.ReadInt(CFG_IDENT, "show_permissions", 1) == 1)
			{
				Addons[i] = new AddOn.Permissions.Permissions();
				i++;
			}

			if (cfg.ReadInt(CFG_IDENT, "show_editor", 1) == 1)
			{
				Addons[i] = new AddOn.Editor.Editor();
				i++;
			}

			if (cfg.ReadInt(CFG_IDENT, "show_backup", 1) == 1)
			{
				Addons[i] = new AddOn.Backup.Backup();
				i++;
			}

			if (cfg.ReadInt(CFG_IDENT, "show_forwarder", 1) == 1)
			{
				Addons[i] = new AddOn.Forwarder.Forwarder();
				i++;
			}

			//This tab can't be disabled
			//if (cfg.ReadInt(CFG_IDENT, "show_settings", 1) == 1)
			//{
				Addons[i] = new AddOn.Settings.Settings();
				i++;
			//}

			for (byte j=0;j<=i;j++)
			{
				if (!( Addons[j] is AddOn.IAddon)) continue; //if not set
				logger.Log(LogLevel.Info, "mainform", "loading addon", Addons[j].name);
				Addons[j].Initialize(); // initialize
				logger.Log(LogLevel.Info, "mainform", "initialized addon", Addons[j].name);
				if (Addons[j].Tabpage == null) continue; // If no tabpage is available, skip loading
				TabCtrlAddons.TabPages.Add(Addons[j].Tabpage);
				logger.Log(LogLevel.Info, "mainform", "added addon tabpage", Addons[j].name);
			}
		}

    }
}
