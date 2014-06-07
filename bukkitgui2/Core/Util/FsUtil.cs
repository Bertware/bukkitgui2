// FsUtil.cs in bukkitgui2/bukkitgui2
// Created 2014/01/31
// Last edited at 2014/06/07 20:24
// ©Bertware, visit http://bertware.net

using System.IO;

namespace Net.Bertware.Bukkitgui2.Core.Util
{
	internal static class FsUtil
	{
		/// <summary>
		///     Create a directory, only if it doesn't exist.
		/// </summary>
		/// <param name="directory"></param>
		public static void CreateDirectoryIfNotExists(string directory)
		{
			if (Directory.Exists(directory)) return;

			Directory.CreateDirectory(directory);
		}
	}
}