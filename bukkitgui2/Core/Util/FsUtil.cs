namespace Bukkitgui2.Core.Util
{
	internal static class FsUtil
	{
        /// <summary>
        /// Create a directory, only if it doesn't exist.
        /// </summary>
        /// <param name="directory"></param>
		public static void CreateDirectoryIfNotExists(string directory)
		{
			if (System.IO.Directory.Exists(directory)) return;

			System.IO.Directory.CreateDirectory(directory);
		}
	}
}