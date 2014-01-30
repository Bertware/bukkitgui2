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

		private const string log_folder = "\\log\\";
		private const string conf_folder = "\\config\\";
		private const string tmp_folder = "\\temp\\";

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
        public string Location(RequestFile File)
        { 
            switch (File)
            {
                case RequestFile.Appdata:
                    return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + appdata_subfolder;
                case  RequestFile.Local:
                    return AppDomain.CurrentDomain.BaseDirectory + local_subfolder;
                case RequestFile.StorageRoot:
					return Location(RequestFile.Appdata); //Should return appdata or local, right now always appdata
				case RequestFile.Log:
					return Location(RequestFile.StorageRoot) + log_folder;
				case RequestFile.Config:
					return Location(RequestFile.StorageRoot) + conf_folder;
				case RequestFile.Temp:
					return Location(RequestFile.StorageRoot) + tmp_folder;
                default:
                    return Location(RequestFile.StorageRoot);
            }
        }
	}
}
