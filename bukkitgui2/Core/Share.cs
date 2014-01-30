using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bukkitgui2.Core
{
	static class Share
	{
		static public Core.Locale.ILocale Locale = null;
		static public Core.Configuration.IConfig Config = null;
		static public Core.Filesystem.IFilesystem ServerFileSystem = null;
		static public Core.Logging.ILogger Logger = null;
		static public Core.FileLocation.IFileLocation FileLocation = null;
        static public IntPtr MainFormHandle;

		static public void initialize()
		{
			FileLocation = new Core.FileLocation.DefaultFileLocation();

			Logger = new Logging.FileLogger();
			Locale = new Locale.XmlLocale();
			Config = new Configuration.XmlConfig();

			//The filesystem to use (Only for server actions! e.g. logging and config are handled through the normal filesystem
			//This can be changed later on
			//e.g. when FTP connection settings are read from config or user presses connect button
			ServerFileSystem = new Filesystem.Local.LocalFileSystem(); 

		}

	}
}
