using System;

namespace bukkitgui2.Core.FileLocation
{
	class DefaultFileLocation : IFileLocation
	{
		public DefaultFileLocation()
		{
			isInitialized = false;
		}

		private const string AppdataSubfolder = "\\Bertware\\bukkitgui2\\";
        private const string LocalSubfolder = "\\bukkitgui2\\";

		private const string LogFolder = "\\log\\";
		private const string ConfFolder = "\\config\\";
		private const string TmpFolder = "\\temp\\";

		/// <summary>
		/// Indicates wether this component is initialized and can be used
		/// </summary>
		public bool isInitialized { get; private set; }

		/// <summary>
		/// Create or open needed files, create streams if needed, do everything what's needed before a Log() call can be made
		/// </summary>
        void IFileLocation.Initialize()
		{
			isInitialized = true;
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
		/// <param name="file">the file type you want the parent directory for</param>
		/// <returns></returns>
        public string Location(RequestFile file)
        { 
            switch (file)
            {
                case RequestFile.Appdata:
                    return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + AppdataSubfolder;
                case  RequestFile.Local:
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
}
