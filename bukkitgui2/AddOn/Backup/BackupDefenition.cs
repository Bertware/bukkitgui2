// BackupDefenition.cs in bukkitgui2/bukkitgui2
// Created 2014/09/07
// Last edited at 2015/08/01 12:48
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using MetroFramework;
using Net.Bertware.Bukkitgui2.Core;
using Net.Bertware.Bukkitgui2.Core.FileLocation;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.Core.Util;

namespace Net.Bertware.Bukkitgui2.AddOn.Backup
{
	public class BackupDefenition
	{
		private readonly List<string> _files = new List<string>();
		private readonly List<string> _folders = new List<string>();
		public bool Compression { get; private set; }
		public string TargetDirectory { get; private set; }
		public string Name { get; private set; }

		public List<string> Files
		{
			get { return _files; }
		}

		public List<string> Folders
		{
			get { return _folders; }
		}

		private void AddFile(string file)
		{
			Files.Add(file);
		}

		private void AddFolder(string folder)
		{
			Files.Add(folder);
		}

		/// <summary>
		///     Load all folders and files from the xml defenition
		/// </summary>
		/// <param name="xmle">The xml element defining the backup</param>
		/// <returns>Returns the backup defenition</returns>
		public static BackupDefenition LoadXml(XmlElement xmle)
		{
			if (xmle != null)
			{
				BackupDefenition bd = new BackupDefenition();
				try
				{
					bd.Name = xmle.GetAttribute("name");

					XmlElement foldersElement = (XmlElement) xmle.GetElementsByTagName("folders")[0];
					foreach (string folder in foldersElement.InnerText.Split(';'))
					{
						string entry = folder.Trim(';').Trim();
						if (Directory.Exists(entry)) bd.AddFolder(entry);
						if (File.Exists(entry)) bd.AddFile(entry);
					}

					XmlElement destinationE = (XmlElement) xmle.GetElementsByTagName("destination")[0];
					bd.TargetDirectory = destinationE.InnerText;

					XmlElement compressionE = (XmlElement) xmle.GetElementsByTagName("compression")[0];
					bd.Compression = (compressionE.InnerText.ToLower() == "true");

					Logger.Log(LogLevel.Info, "Backupmanager", "Loaded backup:" + bd.Name + " :Backup enabled");
				}
				catch (Exception ex)
				{
					Logger.Log(LogLevel.Warning, "Backupmanager", "Could not load backup:" + ex.Message);
					return null;
				}
				return bd;
			}
			Logger.Log(LogLevel.Warning, "Backupmanager", "Skipped backup! Wrong XML");
			MetroMessageBox.Show(Application.OpenForms[0],
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
			string backupfolder = "\\backup_" + Name + "_" + DateTime.Now.Ticks/10000000;
			// divide by 10 000 000 for a shorter name
			string savedir = TargetDirectory + backupfolder;
			string target = TargetDirectory + backupfolder;

			try
			{
				// if we need to compress, move to intermediary folder
				if (Compression) target = Fl.SafeLocation(RequestFile.Temp) + backupfolder;

				foreach (string folder in _folders)
				{
					DirectoryInfo di = new DirectoryInfo(folder);
					FsUtil.CopyFolder(di.FullName, target);
				}
				foreach (var file in _files)
				{
					FileInfo fi = new FileInfo(file);
					FsUtil.CopyFolder(fi.FullName, target);
				}
				if (Compression)
				{
					// compress target to savedir.zip
					Core.Util.Compression.Compress(target,
						savedir + ".zip");
					// delete temporary folder
					Directory.Delete(target,true);
				}
					
			}
			catch (PathTooLongException)
			{
				MetroMessageBox.Show(Application.OpenForms[0],
					Locale.Tr(
						"A backup couldn't be executed. The path is too long! Try using shorter filenames.") +
					Environment.NewLine + "Backup name:" + Name,
					Locale.Tr("Backup failed"),
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			catch (Exception)
			{
				MetroMessageBox.Show(Application.OpenForms[0],
					Locale.Tr(
						"A backup couldn't be executed. Maybe you don't have sufficient rights, or maybe the files are locked by another application.") +
					Environment.NewLine + "Backup name:" + Name,
					Locale.Tr("Backup failed"),
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}
	}
}