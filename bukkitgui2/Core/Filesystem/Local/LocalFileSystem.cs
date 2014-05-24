// LocalFileSystem.cs in bukkitgui2/bukkitgui2
// Created 2014/01/18
// Last edited at 2014/05/24 12:16
// ©Bertware, visit http://bertware.net

namespace Net.Bertware.Bukkitgui2.Core.Filesystem.Local
{
	internal class LocalFileSystem : IFilesystem
	{
		/// <summary>
		///     Private isInitialized variable to store the value that will be returned on the public get request
		/// </summary>
		private bool _isInitialized = false;

		/// <summary>
		///     True if this component is initialized and can be used
		/// </summary>
		public bool isInitialized
		{
			get { return _isInitialized; }
		}

		/// <summary>
		///     Create or open needed files, create streams if needed, do everything what's needed before the code can be used
		/// </summary>
		public void Initialize()
		{
		}

		/// <summary>
		///     Stop and clean up
		/// </summary>
		public void Dispose()
		{
		}
	}
}