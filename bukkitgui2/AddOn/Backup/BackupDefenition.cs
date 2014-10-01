// BackupDefenition.cs in bukkitgui2/bukkitgui2
// Created 2014/09/07
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Net.Bertware.Bukkitgui2.Core;
using Net.Bertware.Bukkitgui2.Core.FileLocation;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.Core.Util;

namespace Net.Bertware.Bukkitgui2.AddOn.Backup
{
    public class BackupDefenition
    {
        public string Name;
        public List<string> Folders = new List<string>();
        public List<string> Files = new List<string>();
        public bool Compression = false;
        public string TargetDirectory;

        public BackupDefenition LoadXml(XmlElement xmle)
        {
            if (xmle != null)
            {
                try
                {
                    BackupDefenition bs = new BackupDefenition();
                    Name = xmle.GetAttribute("name");
                    XmlElement foldersElement = (XmlElement) xmle.GetElementsByTagName("folders")[0];
                    foreach (string folder in foldersElement.InnerText.Split(';'))
                    {
                        Folders.Add(folder.Trim(';').Trim());
                    }

                    XmlElement destinationE = (XmlElement) xmle.GetElementsByTagName("destination")[0];
                    TargetDirectory = destinationE.InnerText;

                    XmlElement compressionE = (XmlElement) xmle.GetElementsByTagName("compression")[0];
                    Compression = (compressionE.InnerText.ToLower() == "true");

                    Logger.Log(LogLevel.Info, "Backupmanager", "Loaded backup:" + bs.Name + " :Backup enabled");
                }
                catch (Exception ex)
                {
                    Logger.Log(LogLevel.Warning, "Backupmanager", "Could not load backup:" + ex.Message);
                    return null;
                }
                return this;
            }
            Logger.Log(LogLevel.Warning, "Backupmanager", "Skipped backup! Wrong XML");
            MessageBox.Show(
                Locale.Tr(
                    "One of your backup profiles wasn't loaded: the file is probably corrupt! The backup profile was removed."),
                Locale.Tr("Can't load backup profile"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        /// <summary>
        ///     Execute this backup
        /// </summary>
        public void Execute()
        {
            string backupfolder = "\\backup_" + Name + "_" + DateTime.Now.Ticks;
            string savedir = TargetDirectory + backupfolder;
            string target = TargetDirectory + backupfolder;

            if (Compression) target = Fl.SafeLocation(RequestFile.Temp) + backupfolder;
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
                    savedir + ".zip");
        }
    }
}