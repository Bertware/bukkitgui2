using System;
using  Net.Bertware.Bukkitgui2.Core.Configuration;
using  Net.Bertware.Bukkitgui2.Core.FileLocation;
using  Net.Bertware.Bukkitgui2.Core.Logging;

namespace Net.Bertware.Bukkitgui2.Core
{
    using System.IO;

    internal static class Share
	{
		public static Filesystem.IFilesystem ServerFileSystem = null;
		public static IntPtr MainFormHandle;

		public readonly static string AssemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
		public readonly static Version AssemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
		public readonly static string AssemblyFullName = System.Reflection.Assembly.GetExecutingAssembly().GetName().FullName;
        public static readonly string AssemblyLocation = new FileInfo(AssemblyFullName).DirectoryName;

		public static void Initialize()
		{
			DefaultFileLocation.Initialize();
			Logger.Initialize();

			Config.Initialize();

			Locale.Initialize();


			//The filesystem to use (Only for server actions! e.g. logging and config are handled through the normal filesystem
			//This can be changed later on
			//e.g. when FTP connection settings are read from config or user presses connect button
			ServerFileSystem = new Filesystem.Local.LocalFileSystem();
		}
	}
}