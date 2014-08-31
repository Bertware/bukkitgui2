// FsUtil.cs in bukkitgui2/bukkitgui2
// Created 2014/01/31
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

		public static string ReadFileInUse(string path)
		{
			string result = "";
			using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			{
				using (StreamReader reader = new StreamReader(stream))
				{
					while (!reader.EndOfStream)
					{
						result += reader.ReadToEnd();
					}
				}
			}
			return result;
		}
	}
}