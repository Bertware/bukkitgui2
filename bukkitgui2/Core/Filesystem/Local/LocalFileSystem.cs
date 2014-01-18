using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bukkitgui2.Core.Filesystem.Local
{
	class LocalFileSystem : IFilesystem
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
		/// Create or open needed files, create streams if needed, do everything what's needed before a Log() call can be made
		/// </summary>
		public void Initialize();

		/// <summary>
		/// Stop the logger, dispose used sources
		/// </summary>
		public void Dispose();

	}
}
