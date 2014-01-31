using bukkitgui2.Core.Logging;
using bukkitgui2.Core.Configuration;
using System.Windows.Forms;

namespace bukkitgui2.UI
{
    public partial class MainForm : Form
    {
		private const string CfgIdent = "mainform";

		private readonly IConfig _cfg;
		private readonly ILogger _logger;

        public MainForm()
        {
			Core.Share.MainFormHandle = Handle; //Immediatly set the handle for form operations, tray issues, etc...

            // We need to load all the background stuff before we can start running the application
            // This can take a couple of seconds, so show a splashscreen
            // We have a splashscreen class that loads everything multithreaded, we just need it to show and wait until it's finished.
            var splash = new SplashScreen(); // Create splashscreen
            splash.ShowDialog(); // Call ShowDialog(). This will show the splashscreen on foreground until it closes.

			_cfg = Core.Share.Config;
			_logger = Core.Share.Logger;

            // Start loading everything to the UI
            InitializeComponent();

			_logger.Log(LogLevel.Info, "mainform", "starting to load mainform UI");

			LoadTabs();
        }

		
		private AddOn.IAddon[] _addons ;
		
		/// <summary>
		/// Load all tabpages to the mainform
		/// </summary>
		private void LoadTabs()
		{
			//Create and store a list with the loaded tabs, then load them to the UI.

			_addons=new AddOn.IAddon[16];
			
			byte i = 0;

			//This tab can't be disabled
			//if (cfg.ReadInt(CFG_IDENT, "show_console", 1) == 1)
			//{
			_addons[i] = new AddOn.Console.Console();
			i++;
			//}

			if (_cfg.ReadInt(CfgIdent,"show_players",1) == 1)
			{
				_addons[i] = new AddOn.Playerlist.PlayerList();
				i++;
			}

			//This tab can't be disabled
			//if (cfg.ReadInt(CFG_IDENT, "show_starter", 1) == 1)
			//{
				_addons[i] = new AddOn.Starter.Starter();
				i++;
			//}

			if (_cfg.ReadInt(CfgIdent, "show_tasker", 1) == 1)
			{
				_addons[i] = new AddOn.Tasker.Tasker();
				i++;
			}

			if (_cfg.ReadInt(CfgIdent, "show_plugins", 1) == 1)
			{
				_addons[i] = new AddOn.Plugins.Plugins();
				i++;
			}

			if (_cfg.ReadInt(CfgIdent, "show_permissions", 1) == 1)
			{
				_addons[i] = new AddOn.Permissions.Permissions();
				i++;
			}

			if (_cfg.ReadInt(CfgIdent, "show_editor", 1) == 1)
			{
				_addons[i] = new AddOn.Editor.Editor();
				i++;
			}

			if (_cfg.ReadInt(CfgIdent, "show_backup", 1) == 1)
			{
				_addons[i] = new AddOn.Backup.Backup();
				i++;
			}

			if (_cfg.ReadInt(CfgIdent, "show_forwarder", 1) == 1)
			{
				_addons[i] = new AddOn.Forwarder.Forwarder();
				i++;
			}

			//This tab can't be disabled
			//if (cfg.ReadInt(CFG_IDENT, "show_settings", 1) == 1)
			//{
				_addons[i] = new AddOn.Settings.Settings();
				i++;
			//}

			for (byte j=0;j<=i;j++)
			{
				if ( _addons[j] == null) continue; //if not set
				_logger.Log(LogLevel.Info, "mainform", "loading addon", _addons[j].name);
				_addons[j].Initialize(); // initialize
				_logger.Log(LogLevel.Info, "mainform", "initialized addon", _addons[j].name);
				if (_addons[j].Tabpage == null) continue; // If no tabpage is available, skip loading
				TabCtrlAddons.TabPages.Add(_addons[j].Tabpage);
				_logger.Log(LogLevel.Info, "mainform", "added addon tabpage", _addons[j].name);
			}
		}

    }
}
