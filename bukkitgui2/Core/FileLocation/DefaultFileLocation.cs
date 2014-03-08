using System;

namespace Bukkitgui2.Core.FileLocation
{
	internal static class DefaultFileLocation
	{
		private const string AppdataSubfolder = "\\Bertware\\Bukkitgui2\\";
		private const string LocalSubfolder = "\\Bukkitgui2\\";

		private const string LogFolder = "\\log\\";
		private const string ConfFolder = "\\config\\";
		private const string TmpFolder = "\\temp\\";

		/// <summary>
		///     Indicates wether this component is initialized and can be used
		/// </summary>
		public static bool IsInitialized { get; private set; }

		/// <summary>
		///     Create or open needed files, create streams if needed, do everything what's needed before a Log() call can be made
		/// </summary>
		public static void Initialize()
		{
			IsInitialized = true;
		}

		/// <summary>
		///     Stop the logger, dispose used sources
		/// </summary>
		public static void Dispose()
		{
		}

		/// <summary>
		///     Return the location for a Request
		/// </summary>
		/// <param name="file">the file type you want the parent directory for</param>
		/// <returns></returns>
		public static string Location(RequestFile file)
		{
			switch (file)
			{
				case RequestFile.Appdata:
					return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + AppdataSubfolder;
				case RequestFile.Local:
					return AppDomain.CurrentDomain.BaseDirectory + LocalSubfolder;
				case RequestFile.StorageRoot:
					return Location(RequestFile.Appdata); //Should return appdata or local, right now always appdata
				case RequestFile.Log:
					return Location(RequestFile.StorageRoot) + LogFolder;
				case RequestFile.Config:
					return Location(RequestFile.StorageRoot) + ConfFolder;
				case RequestFile.Temp:
					return Location(RequestFile.StorageRoot) + TmpFolder;
				default:
					return Location(RequestFile.StorageRoot);
			}
		}
	}

	/// <summary>
	///     Request files, unlisted files build upon StorageRoot
	///     Config for config folder
	///     Log for log folder
	///     Temp for temporary files folder
	///     Appdata for the app's folder in appdata
	///     Local for the (a) local folder
	/// </summary>
	internal enum RequestFile
	{
		StorageRoot,
		Config,
		Log,
		Appdata,
		Local,
		Temp
	}
}