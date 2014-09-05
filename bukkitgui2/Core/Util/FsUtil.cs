// FsUtil.cs in bukkitgui2/bukkitgui2
// Created 2014/01/31
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
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