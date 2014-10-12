// DefaultFileLocation.cs in bukkitgui2/bukkitgui2
// Created 2014/01/18
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.IO;
using System.Linq;
using Microsoft.Win32;
using Net.Bertware.Bukkitgui2.Core.Logging;

namespace Net.Bertware.Bukkitgui2.Core.FileLocation
{
	/// <summary>
	///     FileLocation: Provides paths to all commonly used folders for consistent use of the same folders
	/// </summary>
	internal static class Fl
	{
		private static string _workingdirectory;
		private static bool _customWorkingDirectory;
		private const string AppdataSubfolder = "\\Bertware\\Bukkitgui2\\";
		private const string LocalSubfolder = "\\Bukkitgui2\\";

		private const string LogFolder = "\\log\\";
		private const string ConfFolder = "\\config\\";
		private const string LangFolder = "\\lang\\";
		private const string TmpFolder = "\\temp\\";
		private const string CacheFolder = "\\cache\\";

		/// <summary>
		///     Indicates wether this component is initialized and can be used
		/// </summary>
		public static bool IsInitialized { get; private set; }

		/// <summary>
		///     Create or open needed files, create streams if needed, do everything what's needed before a Log() call can be made
		/// </summary>
		public static void Initialize()
		{
			//set working directory
			Environment.CurrentDirectory = Share.AssemblyLocation;

			IsInitialized = true;
			_workingdirectory = SafeLocation(RequestFile.Appdata);

			try
			{
				// -portable argument for keeping everything in the working directory
				if (Environment.GetCommandLineArgs().Contains("-portable") || GetLocal())
				{
					_workingdirectory = Environment.CurrentDirectory;
				}

				// custom working directory

				foreach (string arg in Environment.GetCommandLineArgs())
				{
					if (!arg.Contains("-wd=")) continue;
					_workingdirectory = arg.Split('=')[1];
					Environment.CurrentDirectory = _workingdirectory;
					_customWorkingDirectory = true;
					break;
				}

				// clear the temporary files
				if (Directory.Exists(Location(RequestFile.Temp))) Directory.Delete(Location(RequestFile.Temp), true);
			}
			catch (Exception exception)
			{
				Logger.Log(LogLevel.Severe, "DefaultFileLocation", "Exception thrown while initialising!",
					exception.Message);
			}
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
				case RequestFile.GuiDir:
					return Share.AssemblyLocation;
				case RequestFile.Local:
					return Location(RequestFile.GuiDir) + LocalSubfolder;
				case RequestFile.StorageRoot:
					return _workingdirectory;
				case RequestFile.Log:
					return Location(RequestFile.StorageRoot) + LogFolder;
				case RequestFile.Config:
					return Location(RequestFile.StorageRoot) + ConfFolder;
				case RequestFile.Language:
					return Location(RequestFile.StorageRoot) + LangFolder;
				case RequestFile.Temp:
					return Location(RequestFile.StorageRoot) + TmpFolder;
				case RequestFile.Cache:
					return Location(RequestFile.StorageRoot) + CacheFolder;
				case RequestFile.Serverdir:
					if (!_customWorkingDirectory)
						return Location(RequestFile.GuiDir);
					return _workingdirectory;
				case RequestFile.Plugindir:
					return Location(RequestFile.Serverdir) + "\\plugins";
				default:
					return Location(RequestFile.StorageRoot);
			}
		}

		/// <summary>
		///     Return the location for a certain file type. Create the folder if it doesn't exist.
		/// </summary>
		/// <param name="file">the file type you want the parent directory for</param>
		/// <returns></returns>
		public static string SafeLocation(RequestFile file)
		{
			string location = Location(file);
			if (!Directory.Exists(location)) Directory.CreateDirectory(location);
			return location;
		}

		/// <summary>
		///     Set/Unset the storage location to gui folder
		/// </summary>
		/// <param name="local">True to enable local files</param>
		public static void SetLocal(bool local)
		{
			RegistryKey key = Registry.CurrentUser.CreateSubKey("software\\bertware\\bukkitgui2");
			if (key != null) key.SetValue("local", local);
		}

		/// <summary>
		///     Check if the GUI folder should be used for storage
		/// </summary>
		public static bool GetLocal()
		{
			RegistryKey key = Registry.CurrentUser.CreateSubKey("software\\bertware\\bukkitgui2");
		    if (key == null) return false;

		    object v = key.GetValue("local");
		    bool b;
		    if (v != null && bool.TryParse(v.ToString(), out b)) return b;
		    return false;
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
		GuiDir,
		StorageRoot,
		Config,
		Log,
		Appdata,
		Local,
		Language,
		Temp,
		Serverdir,
		Plugindir,
		Cache
	}
}