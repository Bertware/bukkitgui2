using System.IO;

namespace Net.Bertware.Bukkitgui2.Core.Util
{
	internal static class FsUtil
	{
		/// <summary>
		/// Create a directory, only if it doesn't exist.
		/// </summary>
		/// <param name="directory"></param>
		public static void CreateDirectoryIfNotExists(string directory)
		{
			if (Directory.Exists(directory)) return;

			Directory.CreateDirectory(directory);
		}
	}
}