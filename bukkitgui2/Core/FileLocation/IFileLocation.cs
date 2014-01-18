using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bukkitgui2.Core.FileLocation
{
	/// <summary>
	/// Provide each class the paths to their files
	/// </summary>
	interface IFileLocation
	{
		/// <summary>
		/// Private isInitialized variable to store the value that will be returned on the public get request
		/// </summary>
		private bool _isInitialized;

		/// <summary>
		/// True if this component is initialized and can be used
		/// </summary>
		public readonly bool isInitialized;

		/// <summary>
		/// Request files, unlisted files build upon StorageRoot
		/// Config for config folder
		/// Log for log folder
		/// Temp for temporary files folder
		/// Appdata for the app's folder in appdata
		/// Local for the (a) local folder
		/// </summary>
		enum RequestFile{StorageRoot, Config, Log, Appdata, Local, Temp}

		/// <summary>
		/// Create or open needed files, create streams if needed, do everything what's needed before a Log() call can be made
		/// </summary>
		public void Initialize();

		/// <summary>
		/// Stop the logger, dispose used sources
		/// </summary>
		public void Dispose();

		/// <summary>
		/// Return the location for a Request
		/// </summary>
		/// <param name="File"></param>
		/// <returns></returns>
		public string Location(RequestFile File);
	}
}
