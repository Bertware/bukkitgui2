using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bukkitgui2.Core.FileLocation
{
	/// <summary>
	/// Provide each class the paths to their files
	/// </summary>
	interface IFileLocation
	{

        /// <summary>
        /// Indicates wether this component is initialized and can be used
        /// </summary>
         bool isInitialized
        {
            get;
        }
		/// <summary>
		/// Create or open needed files, create streams if needed, do everything what's needed before a Log() call can be made
		/// </summary>
		 void Initialize();

		/// <summary>
		/// Stop the logger, dispose used sources
		/// </summary>
		 void Dispose();

		/// <summary>
		/// Return the location for a Request
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		 string Location(RequestFile file);
	}

    /// <summary>
    /// Request files, unlisted files build upon StorageRoot
    /// Config for config folder
    /// Log for log folder
    /// Temp for temporary files folder
    /// Appdata for the app's folder in appdata
    /// Local for the (a) local folder
    /// </summary>
    enum RequestFile { StorageRoot, Config, Log, Appdata, Local, Temp }
}
