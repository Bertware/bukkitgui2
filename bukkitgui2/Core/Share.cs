using System;

namespace Bukkitgui2.Core
{
    using System.IO;

    internal static class Share
	{
		public static Locale.ILocale Locale = null;
		public static Configuration.IConfig Config = null;
		public static Filesystem.IFilesystem ServerFileSystem = null;
		public static Logging.ILogger Logger = null;
		public static FileLocation.IFileLocation FileLocation = null;
		public static IntPtr MainFormHandle;

		public readonly static string AssemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
		public readonly static Version AssemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
		public readonly static string AssemblyFullName = System.Reflection.Assembly.GetExecutingAssembly().GetName().FullName;
        public static readonly string AssemblyLocation = new FileInfo(AssemblyFullName).DirectoryName;

		public static void Initialize()
		{
			FileLocation = new FileLocation.DefaultFileLocation();

			Logger = new Logging.FileLogger();
			Logger.Initialize();

			Config = new Configuration.XmlConfig();
			Config.Initialize();

			Locale = new Locale.XmlLocale();
			Locale.Initialize();


			//The filesystem to use (Only for server actions! e.g. logging and config are handled through the normal filesystem
			//This can be changed later on
			//e.g. when FTP connection settings are read from config or user presses connect button
			ServerFileSystem = new Filesystem.Local.LocalFileSystem();
		}
	}
}