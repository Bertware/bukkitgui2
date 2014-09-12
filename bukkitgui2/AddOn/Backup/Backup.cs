// Backup.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.Core.FileLocation;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.Core.Util;

namespace Net.Bertware.Bukkitgui2.AddOn.Backup
{
	public class Backup : IAddon
	{
		public static Backup Reference;

		public Backup()
		{
			Reference = this;
			Name = "Backup";
			HasTab = true;
			TabPage = new BackupTab();
			HasConfig = false;
			ConfigPage = null;
			
		}

		/// <summary>
		///     The addon name, ideally this name is the same as used in the tabpage
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		///     True if this addon has a tab page
		/// </summary>
		public bool HasTab { get; private set; }

		/// <summary>
		///     True if this addon has a config field
		/// </summary>
		public bool HasConfig { get; private set; }

		/// <summary>
		///     Initialize all functions and the tabcontrol
		/// </summary>
		public void Initialize()
		{
			_backups = new Dictionary<string, BackupDefenition>();
			if (!File.Exists(_backupXmlPath))
				File.WriteAllText(_backupXmlPath, "<backups></backups>");
			_backupXml = new XmlDocument();
			_backupXml.Load(_backupXmlPath);
			LoadAllBackups();
		}

		public void Dispose()
		{
			// nothing to do
		}

		private Dictionary<string, BackupDefenition> _backups;

		public Dictionary<string, BackupDefenition> Backups
		{
			get { return _backups; }
		}


		/// <summary>
		///     The tab control for this addon
		/// </summary>
		/// <returns>Returns the tabpage</returns>
		public MetroUserControl TabPage { get; private set; }

		public MetroUserControl ConfigPage { get; private set; }

		private readonly string _backupXmlPath = Fl.SafeLocation(RequestFile.Config) + "/backups.xml";

		private XmlDocument _backupXml;
		public event BackupsLoadedEventHandler BackupsLoaded;

		public delegate void BackupsLoadedEventHandler();

		public bool Loaded
		{
			get { return _backups != null; }
		}


		public void LoadAllBackups()
		{
			_backups = new Dictionary<string, BackupDefenition>();
			Logger.Log(LogLevel.Info, "Backupmanager", "Loading backups...");
			XmlElement rootElement = (XmlElement) _backupXml.GetElementsByTagName("backups")[0];
			XmlNodeList elements = rootElement.GetElementsByTagName("backup");
			if (elements.Count > 0)
			{
				for (int i = 0; i <= elements.Count - 1; i++)
				{
					Logger.Log(LogLevel.Info, "Backupmanager", "Parsing backup " + i + 1 + " out of " + elements.Count);
					XmlElement xmle = (XmlElement) elements[i];
					BackupDefenition backup = new BackupDefenition();
					backup.LoadXml(xmle);
					_backups.Add(backup.Name,backup);
				}
			}
			Logger.Log(LogLevel.Info, "Backupmanager", "Loaded backups: " + _backups.Count + " backups loaded");
			if (BackupsLoaded != null)
			{
				BackupsLoaded();
			}
		}

		public void ReloadAllBackups()
		{
			Logger.Log(LogLevel.Info, "Backupmanager", "Reloading _backups...", "BackupManager");
			LoadAllBackups();
		}

		public void AddBackupToXml(BackupDefenition bs)
		{
			try
			{
				string content = "<backup name=\"" + bs.Name + "\">" +
				                 "	<folders>" + StringUtil.ListToCsv(bs.Folders, ';') + "</folders>" +
				                 "	<destination>" + bs.TargetDirectory + "</destination>" +
				                 "	<compression>" + bs.Compression.ToString().ToLower() + "</compression>" +
				                 "</backup>";
				_backupXml.FirstChild.InnerXml += content;

				_backupXml.Save(_backupXmlPath);

				_backups.Add(bs.Name, bs);
				if (BackupsLoaded != null)
				{
					BackupsLoaded();
				}
			}
			catch (Exception ex)
			{
				Logger.Log(LogLevel.Severe, "Backupmanager", "Severe error in addBackup! " + ex.Message);
			}
		}

		public void SaveBackup(BackupDefenition oldBackup, BackupDefenition newBackup)
		{
			Logger.Log(LogLevel.Info, "Backupmanager",
				"Updating backup: " + oldBackup.Name + " - Will be replaced by its updated version");
			DeleteBackup(oldBackup);
			AddBackupToXml(newBackup);
			if (BackupsLoaded != null)
			{
				BackupsLoaded();
			}
		}

		public void DeleteBackup(BackupDefenition bs)
		{
			try
			{
				_backups.Remove(bs.Name);
				foreach (XmlElement xmlElement in _backupXml.ChildNodes)
				{
					if (xmlElement.GetAttribute("name").Equals(bs.Name)) _backupXml.RemoveChild(xmlElement);
				}
			}
			catch (Exception ex)
			{
				Logger.Log(LogLevel.Severe, "Backupmanager", "Severe error in deleteBackup(bs)!", ex.Message);
			}
			if (BackupsLoaded != null)
			{
				BackupsLoaded();
			}
		}

		public void DeleteBackup(string name)
		{
			DeleteBackup(GetBackupByName(name));
		}

		public BackupDefenition GetBackupByName(string name)
		{
			if (_backups.ContainsKey(name)) return _backups[name];
			return null;
		}
	}
}