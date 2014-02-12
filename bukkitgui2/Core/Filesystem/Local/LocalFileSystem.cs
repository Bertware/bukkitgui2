using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bukkitgui2.Core.Filesystem.Local
{
	class LocalFileSystem : IFilesystem
	{
		/// <summary>
		/// Private isInitialized variable to store the value that will be returned on the public get request
		/// </summary>
		private bool _isInitialized = false;

		/// <summary>
		/// True if this component is initialized and can be used
		/// </summary>
		public  bool isInitialized
        {
            get{return _isInitialized;}
        }

		/// <summary>
		/// Create or open needed files, create streams if needed, do everything what's needed before the code can be used
		/// </summary>
        public void Initialize()
        {
        }

		/// <summary>
		/// Stop and clean up
		/// </summary>
		public void Dispose()
        {
        }
	}
}
