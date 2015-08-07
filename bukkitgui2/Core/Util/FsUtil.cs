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

        /// <summary>
        ///     Copy a folder, also works between different drives
        /// </summary>
        /// <param name="sourceFolder">source dir</param>
        /// <param name="destFolder">destination dir</param>
        /// <param name="deleteSource">delete the source? (move)</param>
        public static void CopyFolder(string sourceFolder, string destFolder, bool deleteSource = false)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
	            if (name != null)
	            {
		            string dest = Path.Combine(destFolder, name);
		            File.Copy(file, dest, true);
	            }
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
	            if (name != null)
	            {
		            string dest = Path.Combine(destFolder, name);
		            CopyFolder(folder, dest);
	            }
            }
            if (deleteSource) Directory.Delete(sourceFolder, true);
        }
    }
}