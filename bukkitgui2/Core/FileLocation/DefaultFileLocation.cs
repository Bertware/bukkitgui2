using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bukkitgui2.Core.FileLocation
{
	class DefaultFileLocation : IFileLocation
	{

        private bool _isInitialized = false;
        private const string appdata_subfolder = "\\Bertware\\bukkitgui2\\";
        private const string local_subfolder = "\\bukkitgui2\\";
        /// <summary>
        /// Indicates wether this component is initialized and can be used
        /// </summary>
        bool IFileLocation.isInitialized
        {
            get { return _isInitialized; }
        }
		/// <summary>
		/// Create or open needed files, create streams if needed, do everything what's needed before a Log() call can be made
		/// </summary>
        void IFileLocation.Initialize()
        { 
        }

		/// <summary>
		/// Stop the logger, dispose used sources
		/// </summary>
        void IFileLocation.Dispose()
        { 
        }

		/// <summary>
		/// Return the location for a Request
		/// </summary>
		/// <param name="File"></param>
		/// <returns></returns>
       public string IFileLocation.Location(RequestFile File)
        { 
            switch (File)
            {
                case RequestFile.Appdata:
                    return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + appdata_subfolder;
                case  RequestFile.Local:
                    return AppDomain.CurrentDomain.BaseDirectory + local_subfolder;
                case RequestFile.StorageRoot:
                    return ""
                default:
                    return "";
            }
            return "";
        }
	}
}
