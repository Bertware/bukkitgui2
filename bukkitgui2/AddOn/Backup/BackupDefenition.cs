// BackupDefenition.cs in bukkitgui2/bukkitgui2
// Created 2014/09/07
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.IO;
using Net.Bertware.Bukkitgui2.Core.FileLocation;
using Net.Bertware.Bukkitgui2.Core.Util;

namespace Net.Bertware.Bukkitgui2.AddOn.Backup
{
	public class BackupDefenition
	{
		public string Name;
		public string[] Folders = new string[0];
		public string[] Files = new string[0];
		public bool Compression = false;

		/// <summary>
		///     Execute this backup
		/// </summary>
		/// <param name="savedir"></param>
		public void Execute(string savedir)
		{
			string target = savedir;
			if (Compression) target = Fl.SafeLocation(RequestFile.Temp) + "/backup_" + DateTime.Now.Ticks + "/";
			foreach (string folder in Folders)
			{
				DirectoryInfo di = new DirectoryInfo(folder);
				FsUtil.CopyFolder(di.FullName, target);
			}
			foreach (string file in Files)
			{
				FileInfo fi = new FileInfo(file);
				FsUtil.CopyFolder(fi.FullName, target);
			}
			if (Compression)
				Core.Util.Compression.Compress(target,
					savedir + Name + DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString());
		}
	}
}